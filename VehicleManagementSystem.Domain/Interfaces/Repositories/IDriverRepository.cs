using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories
{
    public interface IDriverRepository {
        Task<DriverEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<DriverEntity>?> GetAllByTeamIdAsync(Guid teamId, CancellationToken cancellationToken);
        Task<List<DriverEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(DriverEntity driver, CancellationToken cancellationToken);
        Task UpdateAsync(DriverEntity driver, CancellationToken cancellationToken);
        Task DeleteAsync(DriverEntity driver, CancellationToken cancellationToken);
    }
}
