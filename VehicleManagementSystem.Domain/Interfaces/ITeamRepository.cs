using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces {
    public interface ITeamRepository {
        Task<TeamEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
