using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface IRouteAssignmentRepository {
        Task<RouteAssignmentEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<RouteAssignmentEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task<List<RouteAssignmentEntity>?> GetAllByRouteIdAsync(Guid routeId, CancellationToken cancellationToken);
        Task<List<RouteAssignmentEntity>?> GetAllByTransportIdAsync(Guid trasnportId, CancellationToken cancellationToken);
        Task AddAsync(RouteAssignmentEntity route, CancellationToken cancellationToken);
        Task UpdateAsync(RouteAssignmentEntity route, CancellationToken cancellationToken);
        Task DeleteAsync(RouteAssignmentEntity route, CancellationToken cancellationToken);
    }
}
