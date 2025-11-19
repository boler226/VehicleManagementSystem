using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface ITransportRepairRepository : IBaseRepository<TransportRepairEntity>
{
    Task<List<TransportRepairEntity>> GetByGarageIdAsync(Guid GarageId, CancellationToken cancellationToken);
    Task<List<TransportRepairEntity>> GetByTransportIdsAsync(List<Guid> transportIds, CancellationToken cancellationToken);
}