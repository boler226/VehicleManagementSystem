using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings {
    public class TechnicianMappingProfile : Profile {
        public TechnicianMappingProfile() {
            CreateMap<TechnicianEntity, TechnicianShortDto>();
            CreateMap<TechnicianEntity, TechnicianDto>();
        }
    }
}
