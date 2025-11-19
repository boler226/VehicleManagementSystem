using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface IMileageRecordRepository : IBaseRepository<MileageRecordEntity>
{
    Task<List<MileageRecordEntity>> GetByTransportIdAsync(Guid transportId, CancellationToken cancellationToken);
    Task<List<MileageRecordEntity>> GetByDateAsync(DateTime date, CancellationToken cancellationToken);
}
