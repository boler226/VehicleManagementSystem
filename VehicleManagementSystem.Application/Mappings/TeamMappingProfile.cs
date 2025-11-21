using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Team;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings; 
public class TeamMappingProfile : Profile {
    public TeamMappingProfile() {
        CreateMap<TeamEntity, TeamDto>();
        CreateMap<TeamEntity, TeamShortDto>();

        CreateMap<TeamEntity, SubordinatesReportDto>()
            .ForMember(dest => dest.Drivers, opt => opt.MapFrom(src => src.Drivers.Select(d => d.FullName)))
            .ForMember(dest => dest.Technicians, opt => opt.MapFrom(src => src.Technicians.Select(t => t.FullName)));
    }
}
