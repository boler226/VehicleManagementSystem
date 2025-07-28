using AutoMapper;
using VehicleManagementSystem.Application.DTOs;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.RouteAssignment;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings
{
    public class TransportMappingProfile : Profile {
        public TransportMappingProfile() {
            CreateMap<TransportEntity, TransportWithRoutesDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Routes, opt => opt.MapFrom(src => src.RouteAssignments));

            CreateMap<RouteAssignmentEntity, RouteAssignmentDto>();

            CreateMap<TransportEntity, TransportDto>();
            CreateMap<TransportEntity, TransportBasicDto>();

            CreateMap<RouteEntity, RouteDto>();

            CreateMap<RouteAssignmentEntity, RouteAssignmentDto>();
            CreateMap<RouteAssignmentEntity, RouteAssignmentSimpleDto>();

            CreateMap<TransportEntity, TransportShortDto>();

            CreateMap<DriverTransportEntity, DriverShortDto>()
                .ConstructUsing(src => new DriverShortDto {
                    Id = src.Driver.Id,
                    FullName = src.Driver.FullName,
                    LicenseNumber = src.Driver.LicenseNumber
                });
        }
    }
}
