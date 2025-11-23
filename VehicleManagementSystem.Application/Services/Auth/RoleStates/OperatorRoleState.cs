using Microsoft.AspNetCore.Identity;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Enums.Identity;
using VehicleManagementSystem.Domain.Interfaces.Auth;

namespace VehicleManagementSystem.Application.Services.Auth.RoleStates;
public class OperatorRoleState : IRoleState
{
    public async Task AssignRoleAsync(UserEntity user, UserManager<UserEntity> userManager)
    {
        await userManager.AddToRoleAsync(user, UserRoles.OperatorSD);
    }
}