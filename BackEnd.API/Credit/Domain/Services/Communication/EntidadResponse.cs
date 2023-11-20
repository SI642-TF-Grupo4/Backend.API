using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Shared.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services.Communication;

public class EntidadResponse: BaseResponse<Entidad>
{
    public EntidadResponse(string message) : base(message)
    {
    }

    public EntidadResponse(Entidad resource) : base(resource)
    {
    }
}