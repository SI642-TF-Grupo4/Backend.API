using AutoMapper;
using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Resources;

namespace BackEnd.API.Credit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveVehicleResource, Vehicle>();
        
        
    }
}