using MediatR;

namespace VehicleManagementSystem.Application.Commands.DriverTransport.Delete {
    public record DeleteDriverTransportCommand(Guid driverId, Guid transportId) : IRequest<Unit>;
}
