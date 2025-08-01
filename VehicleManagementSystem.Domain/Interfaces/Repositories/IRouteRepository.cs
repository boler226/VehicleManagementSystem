using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface IRouteRepository {
        Task<RouteEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<RouteEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(RouteEntity route, CancellationToken cancellationToken);
        Task UpdateAsync(RouteEntity route, CancellationToken cancellationToken);
        Task DeleteAsync(RouteEntity route, CancellationToken cancellationToken);
    }
}
