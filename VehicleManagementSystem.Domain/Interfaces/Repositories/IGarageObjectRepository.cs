using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface IGarageObjectRepository {
        Task<GarageObjectEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<GarageObjectEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(GarageObjectEntity garage, CancellationToken cancellationToken);
        Task UpdateAsync(GarageObjectEntity garage, CancellationToken cancellationToken);
        Task DeleteAsync(GarageObjectEntity garage, CancellationToken cancellationToken);
    }
}
