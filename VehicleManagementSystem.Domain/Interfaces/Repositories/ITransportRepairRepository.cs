using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface ITransportRepairRepository : IBaseRepository<TransportRepairEntity>
{
    Task<List<TransportRepairEntity>> GetByGarageIdAsync(Guid GarageId, CancellationToken cancellationToken);
}