using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface ITechnicianRepository {
        Task<TechnicianEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<TechnicianEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(TechnicianEntity technician, CancellationToken cancellationToken);
        Task UpdateAsync(TechnicianEntity technician, CancellationToken cancellationToken);
        Task DeleteAsync(TechnicianEntity technician, CancellationToken cancellationToken);
    }
}
