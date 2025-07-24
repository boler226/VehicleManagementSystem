using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork(
        IDriverRepository driverRepository,
        ITransportRepository transportRepository,
        ITeamRepository teamRepository,
        IDriverTransportRepository driverTransportRepository
        ) : IUnitOfWork {
        public IDriverRepository Drivers => driverRepository;
        public ITransportRepository Transports => transportRepository;
        public ITeamRepository Teams => teamRepository;
        public IDriverTransportRepository DriverTransports => driverTransportRepository;
    }
}
