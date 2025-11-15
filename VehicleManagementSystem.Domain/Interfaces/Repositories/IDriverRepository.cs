using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;

public interface IDriverRepository : IBaseRepository<DriverEntity>
{
    Task<List<DriverEntity>?> GetAllByTeamIdAsync(Guid teamId, CancellationToken cancellationToken);
}
