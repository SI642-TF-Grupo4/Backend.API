using System.Data;
using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services;

public interface ICreditoService
{
    Task<CreditoResponse> SaveAsync(Credito credito);

    Task<CreditoResponse> FindByUserId(int userId);

    Task<CreditoResponse> DeleteAsync(int creditId);
}