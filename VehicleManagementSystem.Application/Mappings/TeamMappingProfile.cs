using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.Person;
using VehicleManagementSystem.Application.DTOs.Team;
using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings; 
public class TeamMappingProfile : Profile {
    public TeamMappingProfile() {
        CreateMap<TeamEntity, TeamDto>();
        CreateMap<TeamEntity, TeamShortDto>();
    }
}
