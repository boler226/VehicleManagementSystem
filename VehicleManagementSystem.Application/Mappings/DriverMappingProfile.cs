using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings {
    public class DriverMappingProfile : Profile {
        public DriverMappingProfile() {
            CreateMap<DriverEntity, DriverDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(dest => dest.VehicleCount, opt => opt.MapFrom(src => src.Vechicles.Count));

        }
    }
}
