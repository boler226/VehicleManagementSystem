using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;

public interface ITeamRepository : IBaseRepository<TeamEntity>
{
    Task<TeamEntity?> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken);
    Task<TeamEntity?> GetByLeaderIdAsync(Guid leaderId, CancellationToken cancellationToken);
}