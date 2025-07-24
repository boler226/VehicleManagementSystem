using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories
{
    public interface IDriverTransportRepository
    {
        Task<DriverTransportEntity?> GetByDriverIdAsync(Guid driverId, CancellationToken cancellationToken);
        Task AddAsync(DriverTransportEntity driverTransport, CancellationToken cancellationToken);
        Task DeleteByDriverIdAsync(Guid driverId, CancellationToken cancellationToken);
        Task DeleteByTransportIdAsync(Guid transportId, CancellationToken cancellationToken);

    }
}
