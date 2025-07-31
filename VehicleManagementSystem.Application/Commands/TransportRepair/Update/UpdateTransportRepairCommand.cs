using MediatR;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Update {
    public record UpdateTransportRepairCommand(Guid Id, DateTime? RepairDate, double? Cost) : IRequest<Unit>;
}
