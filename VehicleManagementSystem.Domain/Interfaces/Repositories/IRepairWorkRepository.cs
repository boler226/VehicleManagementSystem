using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface IRepairWorkRepository : IBaseRepository<RepairWorkEntity>
{
    Task<List<RepairWorkEntity>> GetByRepairIdAsync(Guid repairId, CancellationToken cancellationToken);
    Task<List<RepairWorkEntity>> GetByTechnicianIdAsync(Guid technicianId, CancellationToken cancellationToken);
}
