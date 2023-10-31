using BackEnd.API.Shared.Persistence.Contexts;

namespace BackEnd.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }
}