using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Route;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings; 
public class RouteMappingProfile : Profile {
    public RouteMappingProfile() { 
        CreateMap<RouteEntity, RouteDto>();
        CreateMap<RouteEntity, RouteShortDto>();
    }
}
