using BackEnd.API.Credit.Domain.Models;

namespace BackEnd.API.Credit.Domain.Repositories;

public interface ICuotaRepository
{
    Task<Cuota> FindByIdAsync(int cuotaId);
    Task<IEnumerable<Cuota>> ListByCreditoId(int creditoId);

    Task AddAsync(Cuota cuota);

    void Update(Cuota cuota);

    void Remove(Cuota cuota);

}