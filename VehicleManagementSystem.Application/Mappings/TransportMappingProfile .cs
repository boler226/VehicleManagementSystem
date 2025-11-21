using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Application.DTOs.TransportRepair;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings;

public class TransportMappingProfile : Profile {
    public TransportMappingProfile() {
        CreateMap<TransportEntity, TransportWithRoutesDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Routes, opt => opt.MapFrom(src => src.Assignments));

        CreateMap<TransportEntity, TransportDto>();
        CreateMap<TransportEntity, TransportShortDto>();

        CreateMap<DriverTransportEntity, DriverShortDto>()
            .ConstructUsing(src => new DriverShortDto {
                Id = src.Driver.Id,
                FullName = src.Driver.FullName
            });

        CreateMap<TransportEntity, TransportRepairStatsDto>()
           .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.Repairs.Sum(r => r.Cost)));

        CreateMap<TransportEntity, TransportAcquisitionWriteOffDto>();
        CreateMap<TransportEntity, CargoTransportReportDto>();
    }
}
