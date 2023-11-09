using BackEnd.API.Shared.Domain.Repositories;
using BackEnd.API.Shared.Persistence.Contexts;

namespace BackEnd.API.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}