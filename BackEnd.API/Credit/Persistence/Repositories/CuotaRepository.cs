using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Shared.Persistence.Contexts;
using BackEnd.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Credit.Persistence.Repositories;

public class CuotaRepository: BaseRepository, ICuotaRepository
{
    public CuotaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Cuota> FindByIdAsync(int cuotaId)
    {
        return await _context.Cuotas
            .Include(c => c.Credito)
            .FirstOrDefaultAsync(c => c.Id == cuotaId);
    }

    public async Task<IEnumerable<Cuota>> ListByCreditoId(int creditoId)
    {
        return await _context.Cuotas
            .Where(c => c.CreditoId == creditoId)
            .Include(c => c.Credito)
            .ToListAsync();
    }

    public async Task AddAsync(Cuota cuota)
    {
        await _context.Cuotas.AddAsync(cuota);
    }

    public void Update(Cuota cuota)
    {
        _context.Update(cuota);
    }

    public void Remove(Cuota cuota)
    {
        _context.Remove(cuota);
    }
}