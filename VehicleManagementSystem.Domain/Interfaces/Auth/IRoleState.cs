using Microsoft.AspNetCore.Identity;
using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.Domain.Interfaces.Auth;
public interface IRoleState
{
    Task AssignRoleAsync(UserEntity user, UserManager<UserEntity> userManager);
}