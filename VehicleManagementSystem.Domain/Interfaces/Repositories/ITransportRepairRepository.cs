using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface ITransportRepairRepository {
        Task<TransportRepairEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<TransportRepairEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(TransportRepairEntity repair, CancellationToken cancellationToken);
        Task UpdateAsync(TransportRepairEntity repair, CancellationToken cancellationToken);
        Task DeleteAsync(TransportRepairEntity repair, CancellationToken cancellationToken);
    }
}
