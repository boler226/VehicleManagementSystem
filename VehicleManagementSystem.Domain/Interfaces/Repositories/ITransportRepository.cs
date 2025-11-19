using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;

public interface ITransportRepository : IBaseRepository<TransportEntity>
{
    Task<List<TransportEntity>> GetByGarageIdAsync(Guid GarageId,CancellationToken cancellationToken);
    Task<List<TransportEntity>> GetByTypeAsync(TransportEnum type, CancellationToken cancellationToken);
    Task<TransportEntity?> GetWithRoutesByPeriodAsync(Guid id, DateTime from, DateTime to, CancellationToken cancellationToken);
}