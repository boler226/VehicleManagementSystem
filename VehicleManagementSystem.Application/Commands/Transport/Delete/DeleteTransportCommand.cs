using MediatR;

namespace VehicleManagementSystem.Application.Commands.Transport.DeleteTransport;

public record DeleteTransportCommand(Guid Id) : IRequest<Unit>;
