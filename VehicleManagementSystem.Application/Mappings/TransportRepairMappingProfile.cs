using AutoMapper;
using VehicleManagementSystem.Application.DTOs.TransportRepair;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings {
    public class TransportRepairMappingProfile : Profile {
        public TransportRepairMappingProfile() {
            CreateMap<TransportRepairEntity, TransportRepairDto>();
            CreateMap<TransportRepairEntity, TransportRepairShortDto>();
        }
    }
}
