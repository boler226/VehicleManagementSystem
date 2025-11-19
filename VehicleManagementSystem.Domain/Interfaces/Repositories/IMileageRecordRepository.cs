using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface IMileageRecordRepository : IBaseRepository<MileageRecordEntity>
{
    Task<List<MileageRecordEntity>> GetByTransportIdAsync(Guid transportId, CancellationToken cancellationToken);
}
