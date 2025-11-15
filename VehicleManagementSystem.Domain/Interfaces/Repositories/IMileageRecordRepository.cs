using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface IMileageRecordRepository : IBaseRepository<MileageRecordEntity>
{
    Task<List<MileageRecordEntity>?> GetAllByTransportIdAsync(Guid transportId, CancellationToken cancellationToken);
}
