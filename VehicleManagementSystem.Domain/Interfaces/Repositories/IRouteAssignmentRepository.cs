using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface IRouteAssignmentRepository : IBaseRepository<RouteAssignmentEntity>
{
    Task<List<RouteAssignmentEntity>?> GetAllByRouteIdAsync(Guid routeId, CancellationToken cancellationToken);
    Task<List<RouteAssignmentEntity>?> GetAllByTransportIdAsync(Guid trasnportId, CancellationToken cancellationToken);
}
