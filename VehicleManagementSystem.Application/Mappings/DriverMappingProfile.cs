using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings {
    public class DriverMappingProfile : Profile {
        public DriverMappingProfile() {
            CreateMap<DriverEntity, DriverDto>()
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.Team));

            CreateMap<DriverEntity, DriverShortDto>();
        }
    }
}
