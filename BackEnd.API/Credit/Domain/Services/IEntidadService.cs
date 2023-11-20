using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services;

public interface IEntidadService
{
    Task<IEnumerable<Entidad>> ListAsync();

    Task<Entidad> GetById(int entidadId);

    Task<EntidadResponse> SaveAsync(Entidad entidad);

    Task<EntidadResponse> Delete(int entidadId);

}