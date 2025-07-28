using MediatR;

namespace VehicleManagementSystem.Application.Commands.DriverTransport.Add {
    public record AddDriverTransportCommand(Guid DriverId, Guid TransportId) : IRequest<Unit>;
}
