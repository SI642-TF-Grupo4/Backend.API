using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Shared.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services.Communication;

public class CreditoResponse : BaseResponse<Credito>
{
    public CreditoResponse(string message) : base(message)
    {
    }

    public CreditoResponse(Credito resource) : base(resource)
    {
    }
}