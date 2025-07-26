using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories
{
    public interface ITeamRepository
    {
        Task<TeamEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<TeamEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(TeamEntity team, CancellationToken cancellationToken);
        Task UpdateAsync(TeamEntity team, CancellationToken cancellationToken);
        Task DeleteAsync(TeamEntity team, CancellationToken cancellationToken);
    }
}
