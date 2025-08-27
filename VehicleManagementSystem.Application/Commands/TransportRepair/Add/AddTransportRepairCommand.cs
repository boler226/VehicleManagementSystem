using MediatR;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Add {
    public record AddTransportRepairCommand(Guid TransportId, Guid? GarageId, double Cost) : IRequest<Guid>;
}
