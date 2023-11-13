using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Shared.Persistence.Contexts;
using BackEnd.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.API.Credit.Persistence.Repositories;

public class CreditRepository: BaseRepository, ICreditRepository
{
    public CreditRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Credito credito)
    {
        await _context.AddAsync(credito);
    }

    public async Task<Credito> FindByUserId(int userId)
    {
        return await _context.Creditos
            .Include(c => c.User)
            .FirstOrDefaultAsync(t => t.UserId == userId);
    }

    public async Task<Credito> FindById(int id)
    {
        return await _context.Creditos
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public void Remove(Credito credito)
    {
        _context.Remove(credito);
    }
}