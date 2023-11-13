using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Shared.Domain.Services.Communication;

namespace BackEnd.API.Credit.Domain.Services.Communication;

public class VehicleResponse: BaseResponse<Vehicle>
{
    public VehicleResponse(string message) : base(message)
    {
    }

    public VehicleResponse(Vehicle resource) : base(resource)
    {
    }
}