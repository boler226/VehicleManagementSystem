using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings; 
public class DriverMappingProfile : Profile {
    public DriverMappingProfile() {
        CreateMap<DriverEntity, DriverDto>()
            .ForMember(dest => dest.Vechicles, opt => opt.MapFrom(src => src.Vechicles));

        CreateMap<DriverTransportEntity, TransportShortDto>()
            .ConstructUsing(src => new TransportShortDto {
                Id = src.Transport.Id,
                LicensePlate = src.Transport.LicensePlate,
                Brand = src.Transport.Brand,
                Model = src.Transport.Model
            });


        CreateMap<DriverEntity, DriverShortDto>();
        CreateMap<DriverEntity, DriverItemDto>()
            .ForMember(dest => dest.TransportModels, opt => opt.MapFrom(src => src.Vechicles));
    }
}
