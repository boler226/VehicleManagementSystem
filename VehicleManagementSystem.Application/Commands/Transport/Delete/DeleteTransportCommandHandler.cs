using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Transport.DeleteTransport;

public class DeleteTransportCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteTransportCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
    {
        var transport = await manager.Transports.GetByIdAsync(request.Id, cancellationToken)
                        ?? throw new NotFoundException(nameof(TransportEntity), request.Id);

        await manager.DriverTransports.DeleteByTransportIdAsync(request.Id, cancellationToken);
        await manager.Transports.DeleteAsync(transport, cancellationToken);

        return Unit.Value;
    }
}
