using BackEnd.API.Credit.Domain.Models;

namespace BackEnd.API.Credit.Domain.Repositories;

public interface ICreditRepository
{
    Task AddAsync(Credito credito);

    Task<Credito> FindByUserId(int userId);

    void Remove(Credito credito);
}