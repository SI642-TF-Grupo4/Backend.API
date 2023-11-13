using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Domain.Services.Communication;
using BackEnd.API.Security.Domain.Repositories;
using BackEnd.API.Shared.Domain.Repositories;

namespace BackEnd.API.Credit.Services;

public class VehicleService:IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public VehicleService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Vehicle> GetById(int id)
    {
        return await _vehicleRepository.FindByIdAsync(id);
    }

    public async Task<Vehicle> ListByUserIdAsync(int userId)
    {
        return await _vehicleRepository.FindByUserId(userId);
    }

    public async Task<VehicleResponse> SaveAsync(Vehicle vehicle)
    {
        //validate existence of the user
        var existingUser = await _userRepository.FindByIdAsync(vehicle.UserId);
        if (existingUser == null)
            return new VehicleResponse("Invalid user");

        var existingVehicleWithPlaca = await _vehicleRepository.FindByPlacaAsync(vehicle.Placa);
        if (existingVehicleWithPlaca != null)
            return new VehicleResponse("Placa is already used.");

        try
        {
            await _vehicleRepository.AddAsync(vehicle);
            await _unitOfWork.CompleteAsync();

            return new VehicleResponse(vehicle);
        }
        catch (Exception e)
        {
            return new VehicleResponse($"An error occurred while saving {e.Message}");
        }
    }

    public async Task<VehicleResponse> DeleteAsync(int vehicleId)
    {
        var existingVehicle = await _vehicleRepository.FindByIdAsync(vehicleId);
        if (existingVehicle == null)
            return new VehicleResponse("Vehicle not found");

        try
        {
            _vehicleRepository.Remove(existingVehicle);
            await _unitOfWork.CompleteAsync();
            return new VehicleResponse(existingVehicle);
        }
        catch (Exception e)
        {
            return new VehicleResponse($"An error occurred while deleting the vehicle: {e.Message}");
        }
    }
}