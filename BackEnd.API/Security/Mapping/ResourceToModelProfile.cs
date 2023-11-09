using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Security.Domain.Services.Communication;

namespace BackEnd.API.Security.Mapping;

public class ResourceToModelProfile : AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
    }
}