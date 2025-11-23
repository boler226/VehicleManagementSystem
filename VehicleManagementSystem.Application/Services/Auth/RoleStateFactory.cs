using VehicleManagementSystem.Application.Services.Auth.RoleStates;
using VehicleManagementSystem.Domain.Enums.Identity;
using VehicleManagementSystem.Domain.Interfaces.Auth;

namespace VehicleManagementSystem.Application.Services.Auth;
public static class RoleStateFactory
{
    public static IRoleState Create(string role)
    {
        return role switch
        {
            UserRoles.AdminSD => new AdminRoleState(),
            UserRoles.OperatorSD => new OperatorRoleState(),
            UserRoles.Authorized => new AuthorizedRoleState(),
            UserRoles.Guest => new GuestRoleState(),
            _ => throw new Exception("Unknown role")
        };
    }
}