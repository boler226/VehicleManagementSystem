using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces {
    public interface IDriverRepository {
        Task<DriverEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(DriverEntity driver, CancellationToken cancellationToken);
        Task UpdateAsync(DriverEntity driver, CancellationToken cancellationToken);
        Task DeleteAsync(DriverEntity driver, CancellationToken cancellationToken);
    }
}
