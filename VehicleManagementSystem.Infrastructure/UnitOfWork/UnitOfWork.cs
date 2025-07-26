using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork(
        IDriverRepository driverRepository,
        ITransportRepository transportRepository,
        ITeamRepository teamRepository,
        IDriverTransportRepository driverTransportRepository,
        IPersonRepository personRepository,
        ITechnicianRepository technicianRepository
        ) : IUnitOfWork {
        public IDriverRepository Drivers => driverRepository;
        public ITransportRepository Transports => transportRepository;
        public ITeamRepository Teams => teamRepository;
        public IDriverTransportRepository DriverTransports => driverTransportRepository;
        public IPersonRepository Persons => personRepository;
        public ITechnicianRepository Technicians => technicianRepository;
    }
}
