using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Shared.Persistence.Contexts;
using BackEnd.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Credit.Persistence.Repositories;

public class VehicleRepository: BaseRepository, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await _context.Vehicles
            .Include(v => v.User)
            .ToListAsync();
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
    }

    public async Task<Vehicle> FindByIdAsync(int id)
    {
        return await _context.Vehicles
            .Include(v => v.User)
            .FirstOrDefaultAsync(v => v.Id==id);
    }

    public void Remove(Vehicle vehicle)
    {
        _context.Remove(vehicle);
    }

    public async Task<Vehicle> FindByUserId(int userId)
    {
        return await _context.Vehicles
            .Include(v => v.User)
            .FirstOrDefaultAsync(v => v.UserId == userId);
    }

    public async Task<Vehicle> FindByPlacaAsync(string placa)
    {
        return await _context.Vehicles
            .Include(v => v.User)
            .FirstOrDefaultAsync(v => v.Placa == placa);
    }
}