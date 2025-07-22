using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Infrastructure.UnitOfWork {
    public class UnitOfWork(
        IDriverRepository driverRepository,
        ITransportRepository transportRepository,
        ITeamRepository teamRepository
        ) : IUnitOfWork {
        public IDriverRepository Drivers => driverRepository;
        public ITransportRepository Transports => transportRepository;
        public ITeamRepository Teams => teamRepository;
    }
}
