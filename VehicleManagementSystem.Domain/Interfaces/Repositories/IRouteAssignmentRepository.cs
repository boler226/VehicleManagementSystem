using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface IRouteAssignmentRepository : IBaseRepository<RouteAssignmentEntity>
{
    Task<List<RouteAssignmentEntity>> GetByRouteIdAsync(Guid routeId, CancellationToken cancellationToken);
    Task<List<RouteAssignmentEntity>> GetByTransportIdAsync(Guid trasnportId, CancellationToken cancellationToken);
    Task<List<RouteAssignmentEntity>> GetByTransportAndPeriodAsync(
        Guid transportId,
        DateTime start,
        DateTime end,
        CancellationToken cancellationToken);

}
