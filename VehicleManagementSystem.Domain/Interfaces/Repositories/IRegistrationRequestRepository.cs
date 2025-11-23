using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;
public interface IRegistrationRequestRepository : IRepository
{
    Task AddAsync(RegistrationRequest request, CancellationToken cancellationToken);
    Task<RegistrationRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<RegistrationRequest>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(RegistrationRequest request, CancellationToken cancellationToken);
}