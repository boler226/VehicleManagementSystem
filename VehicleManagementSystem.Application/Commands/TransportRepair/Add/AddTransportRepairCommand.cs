using MediatR;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Add {
    public record AddTransportRepairCommand(Guid TransportId, double Cost) : IRequest<Guid>;
}
