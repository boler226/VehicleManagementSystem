using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface IMileageRecordRepository {
        Task<MileageRecordEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<MileageRecordEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task<List<MileageRecordEntity>?> GetAllByTransportIdAsync(Guid transportId, CancellationToken cancellationToken);
        Task AddAsync(MileageRecordEntity mileageRecord, CancellationToken cancellationToken);
        Task UpdateAsync(MileageRecordEntity mileageRecord, CancellationToken cancellationToken);
        Task DeleteAsync(MileageRecordEntity mileageRecord, CancellationToken cancellationToken);
    }
}
