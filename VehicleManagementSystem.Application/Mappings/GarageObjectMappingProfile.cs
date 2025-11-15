using AutoMapper;
using VehicleManagementSystem.Application.DTOs.GarageObject;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings; 
public class GarageObjectMappingProfile : Profile {
    public GarageObjectMappingProfile() {
        CreateMap<GarageObjectEntity, GarageObjectDto>();
        CreateMap<GarageObjectEntity, GarageObjectShortDto>();
    }
}
