using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories {
    public interface IPersonRepository {
        Task<PersonEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<PersonEntity>?> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(PersonEntity person, CancellationToken cancellationToken);
        Task UpdateAsync(PersonEntity person, CancellationToken cancellationToken);
        Task DeleteAsync(PersonEntity person, CancellationToken cancellationToken);
    }
}
