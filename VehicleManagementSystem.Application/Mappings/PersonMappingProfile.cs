using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Person;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Application.Mappings {
    public class PersonMappingProfile : Profile {
        public PersonMappingProfile() {
            CreateMap<PersonEntity, PersonDto>();
        }
    }
}
