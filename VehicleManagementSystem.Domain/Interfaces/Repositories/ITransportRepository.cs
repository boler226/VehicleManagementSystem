using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories
{
    public interface ITransportRepository
    {
        Task<TransportEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<TransportEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task<TransportEntity?> GetWithRoutesByPeriodAsync(Guid id, DateTime from, DateTime to, CancellationToken cancellationToken);
        Task AddAsync(TransportEntity transport, CancellationToken cancellation);
        Task UpdateAsync(TransportEntity transport, CancellationToken cancellationToken);
        Task DeleteAsync(TransportEntity transport, CancellationToken cancellationToken);
    }
}
