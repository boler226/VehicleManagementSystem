namespace VehicleManagementSystem.Domain.Interfaces {
    public interface IUnitOfWork {
        IDriverRepository Drivers { get; }
        ITransportRepository Transports { get; } 
        ITeamRepository Teams { get; }
    }
}
