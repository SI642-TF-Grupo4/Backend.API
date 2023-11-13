using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services;

public interface ICuotaService
{
    Task<IEnumerable<Cuota>> ListByCreditId(int creditId);

    Task<CuotaResponse> SaveAsync(Cuota cuota);

    Task<CuotaResponse> UpdateAsync(int cuotaId, Cuota cuota);

    Task<CuotaResponse> DeleteAsync(int cuotaId);

}