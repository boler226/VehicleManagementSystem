using MediatR;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Delete {
    public record DeleteTransportRepairCommand(Guid Id) : IRequest<Unit>;
}
