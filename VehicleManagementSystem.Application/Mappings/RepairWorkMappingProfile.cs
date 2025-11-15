using AutoMapper;
using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings; 
public class RepairWorkMappingProfile : Profile {
    public RepairWorkMappingProfile() {
        CreateMap<RepairWorkEntity, RepairWorkDto>();
        CreateMap<RepairWorkEntity, RepairWorkShortDto>();
    }
}
