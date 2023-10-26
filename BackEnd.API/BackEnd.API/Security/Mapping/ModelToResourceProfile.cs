using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Security.Domain.Services.Communication;
using BackEnd.API.Security.Resources;

namespace BackEnd.API.Security.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}