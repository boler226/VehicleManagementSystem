using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;

public interface ITransportRepository : IBaseRepository<TransportEntity>
{
    Task<List<TransportEntity>?> GetAllByGarageIdAsync(Guid GarageId,CancellationToken cancellationToken);
    Task<TransportEntity?> GetWithRoutesByPeriodAsync(Guid id, DateTime from, DateTime to, CancellationToken cancellationToken);
}