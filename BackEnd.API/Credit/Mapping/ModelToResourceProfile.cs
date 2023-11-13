using AutoMapper;
using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Resources;

namespace BackEnd.API.Credit.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Vehicle, VehicleResource>();

        CreateMap<Credito, CreditoResource>();

        CreateMap<Cuota, CuotaResource>();
    }
}