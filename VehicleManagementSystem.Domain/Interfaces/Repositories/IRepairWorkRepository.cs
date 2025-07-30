using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface IRepairWorkRepository {
        Task<RepairWorkEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<RepairWorkEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task<List<RepairWorkEntity>?> GetAllByTechnicianIdAsync(Guid technicianId, CancellationToken cancellationToken);
        Task AddAsync(RepairWorkEntity work, CancellationToken cancellationToken);
        Task UpdateAsync(RepairWorkEntity work, CancellationToken cancellationToken);
        Task DeleteAsync(RepairWorkEntity work, CancellationToken cancellationToken);
    }
}
