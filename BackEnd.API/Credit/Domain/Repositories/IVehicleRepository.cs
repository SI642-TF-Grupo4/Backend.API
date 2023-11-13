using BackEnd.API.Credit.Domain.Models;

namespace BackEnd.API.Credit.Domain.Repositories;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> ListAsync();
    Task AddAsync(Vehicle vehicle);
    Task<Vehicle> FindByIdAsync(int id);
    void Remove(Vehicle vehicle);
    Task<Vehicle> FindByUserId(int userId);

    Task<Vehicle> FindByPlacaAsync(string placa);

}