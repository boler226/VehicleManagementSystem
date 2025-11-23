using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;
public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}