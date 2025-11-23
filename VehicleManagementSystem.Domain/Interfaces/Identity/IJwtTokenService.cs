using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.Domain.Interfaces.Identity;
public interface IJwtTokenService
{
    string GenerateToken(UserEntity user);
}