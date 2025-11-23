using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Auth;
using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.Application.Mappings;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserEntity, UserDto>();
    }
}