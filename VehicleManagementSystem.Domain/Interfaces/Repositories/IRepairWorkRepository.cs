using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface IRepairWorkRepository : IBaseRepository<RepairWorkEntity>
{
    Task<List<RepairWorkEntity>?> GetAllByRepairIdAsync(Guid repairId, CancellationToken cancellationToken);
    Task<List<RepairWorkEntity>?> GetAllByTechnicianIdAsync(Guid technicianId, CancellationToken cancellationToken);
}
