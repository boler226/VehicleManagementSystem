using AutoMapper;
using VehicleManagementSystem.Application.DTOs.MileageRecord;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings {
    public class MileageRecordMappingProfile : Profile {
        public MileageRecordMappingProfile() {
            CreateMap<MileageRecordEntity, MileageRecordDto>();
            CreateMap<MileageRecordEntity, MileageRecordShortDto>();
        }
    }
}
