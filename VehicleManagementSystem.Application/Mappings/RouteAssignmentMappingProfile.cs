using AutoMapper;
using VehicleManagementSystem.Application.DTOs.RouteAssignment;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings {
    public class RouteAssignmentMappingProfile : Profile {
        public RouteAssignmentMappingProfile() {
            CreateMap<RouteAssignmentEntity, RouteAssignmentDto>();
            CreateMap<RouteAssignmentEntity, RouteAssignmentShortDto>();
        }
    }
}
