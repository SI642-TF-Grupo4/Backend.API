using System.Globalization;
using AutoMapper;
using BackEnd.API.Credit.Domain.Models;
using BackEnd.API.Credit.Resources;

namespace BackEnd.API.Credit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveVehicleResource, Vehicle>();
        CreateMap<SaveEntidadResource, Entidad>();
        CreateMap<SaveCreditoResource, Credito>()
            .ForMember
            (
                dest => dest.FechaDesembolso, opt => opt.MapFrom
                (
                    src => DateTime.ParseExact(
                        src.FechaDesembolso,
                        "dd-MM-yyyy",
                        CultureInfo.InvariantCulture
                    )
                )
            )
            .ForMember
            (
                dest => dest.FechaPrimeraCuota, opt => opt.MapFrom
                (
                    src => DateTime.ParseExact(
                        src.FechaPrimeraCuota,
                        "dd-MM-yyyy",
                        CultureInfo.InvariantCulture
                    )
                )
            );

        CreateMap<SaveCuotaResource, Cuota>();
    }
}