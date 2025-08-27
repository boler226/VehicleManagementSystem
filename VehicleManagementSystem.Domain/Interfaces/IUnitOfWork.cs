using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Domain.Interfaces
{
    public interface IUnitOfWork {
        IDriverRepository Drivers { get; }
        ITransportRepository Transports { get; } 
        ITeamRepository Teams { get; }
        IDriverTransportRepository DriverTransports { get; }
        IPersonRepository Persons { get; }
        ITechnicianRepository Technicians { get; }
        ITransportRepairRepository TransportRepairs { get; }
        IRepairWorkRepository RepairWorks { get; }
        IRouteRepository Routes { get; }
        IRouteAssignmentRepository RouteAssignments { get; }
        IMileageRecordRepository MileageRecords { get; }
    }
}
