using BackEnd.API.Credit.Domain.Models;

namespace BackEnd.API.Credit.Domain.Repositories;

public interface IEntidadRepository
{
    Task<IEnumerable<Entidad>> ListAsync();

    Task AddAsync(Entidad entidad);

    Task<Entidad> FindByIdAsync(int entidadId);

    void Remove(Entidad entidad);
}