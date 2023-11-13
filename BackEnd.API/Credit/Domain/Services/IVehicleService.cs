using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services;

public interface IVehicleService
{
    Task<Vehicle> GetById(int id);
    Task<Vehicle> ListByUserIdAsync(int userId);
    Task<VehicleResponse> SaveAsync(Vehicle vehicle);
    Task<VehicleResponse> DeleteAsync(int vehicleId);
}