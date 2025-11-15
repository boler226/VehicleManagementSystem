using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;

public interface IDriverTransportRepository : IRepository
{
    Task<DriverTransportEntity> GetByIdAsync(Guid driverId, Guid transportId, CancellationToken cancellationToken);
    Task<List<DriverTransportEntity>> GetAllByDriverIdAsync(Guid driverId, CancellationToken cancellationToken);
    Task<List<DriverTransportEntity>> GetAllByTransportIdAsync(Guid transportId, CancellationToken cancellationToken);
    Task AddAsync(DriverTransportEntity driverTransport, CancellationToken cancellationToken);
    Task DeleteByDriverIdAsync(Guid driverId, CancellationToken cancellationToken);
    Task DeleteByTransportIdAsync(Guid transportId, CancellationToken cancellationToken);
    Task DeleteByIdAsync(Guid driverId, Guid transportId, CancellationToken cancellationToken);
}
