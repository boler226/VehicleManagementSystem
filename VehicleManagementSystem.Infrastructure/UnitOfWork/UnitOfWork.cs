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
        ITechnicianRepository technicianRepository,
        ITransportRepairRepository repairRepository,
        IRepairWorkRepository repairWorkRepository,
        IRouteRepository routeRepository,
        IRouteAssignmentRepository assignmentRepository,
        IMileageRecordRepository recordRepository,
        IGarageObjectRepository objectRepository
        ) : IUnitOfWork {
        public IDriverRepository Drivers => driverRepository;
        public ITransportRepository Transports => transportRepository;
        public ITeamRepository Teams => teamRepository;
        public IDriverTransportRepository DriverTransports => driverTransportRepository;
        public IPersonRepository Persons => personRepository;
        public ITechnicianRepository Technicians => technicianRepository;
        public ITransportRepairRepository TransportRepairs => repairRepository;
        public IRepairWorkRepository RepairWorks => repairWorkRepository;
        public IRouteRepository Routes => routeRepository;
        public IRouteAssignmentRepository RouteAssignments => assignmentRepository;
        public IMileageRecordRepository MileageRecords => recordRepository;
        public IGarageObjectRepository GarageObjects => objectRepository;
    }
}
