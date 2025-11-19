using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;

public interface IDriverRepository : IBaseRepository<DriverEntity>
{
    Task<List<DriverEntity>> GetByTeamIdAsync(Guid teamId, CancellationToken cancellationToken);
}
