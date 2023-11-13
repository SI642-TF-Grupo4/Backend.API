using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Shared.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services.Communication;

public class CuotaResponse: BaseResponse<Cuota>
{
    public CuotaResponse(string message) : base(message)
    {
    }

    public CuotaResponse(Cuota resource) : base(resource)
    {
    }
}