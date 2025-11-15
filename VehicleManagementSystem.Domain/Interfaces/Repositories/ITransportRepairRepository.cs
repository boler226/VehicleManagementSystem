using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface ITransportRepairRepository : IBaseRepository<TransportRepairEntity>
{
    Task<List<TransportRepairEntity>?> GetAllByGarageIdAsync(Guid GarageId, CancellationToken cancellationToken);
}