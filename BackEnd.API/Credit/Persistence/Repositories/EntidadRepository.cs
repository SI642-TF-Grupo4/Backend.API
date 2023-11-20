using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Shared.Persistence.Contexts;
using BackEnd.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Credit.Persistence.Repositories;

public class EntidadRepository: BaseRepository, IEntidadRepository
{
    public EntidadRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Entidad>> ListAsync()
    {
        return await _context.Entidades
            .ToListAsync();
    }

    public async Task AddAsync(Entidad entidad)
    {
        await _context.Entidades.AddAsync(entidad);
    }

    public async Task<Entidad> FindByIdAsync(int entidadId)
    {
        return await _context.Entidades
            .FirstOrDefaultAsync(e => e.Id == entidadId);
    }

    public void Remove(Entidad entidad)
    {
        _context.Remove(entidad);
    }
}