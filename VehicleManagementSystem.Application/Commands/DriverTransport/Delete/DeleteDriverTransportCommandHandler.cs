using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.DriverTransport.Delete; 
public class DeleteDriverTransportCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteDriverTransportCommand, Unit> {
    public async Task<Unit> Handle(DeleteDriverTransportCommand request, CancellationToken cancellationToken) {
        var driverTransport = await manager.DriverTransports.GetByIdAsync(request.driverId, request.transportId, cancellationToken)
                              ?? throw new NotFoundException(nameof(DriverEntity) + " or " + nameof(TransportEntity), request.driverId + " or " + request.transportId);

        var transport = await manager.Transports.GetByIdAsync(request.transportId, cancellationToken)
                    ?? throw new NotFoundException(nameof(TransportEntity), request.transportId);

        transport.IsWrittenOff = true;
        transport.WriteOffDate = DateTime.UtcNow;

        await manager.Transports.UpdateAsync(transport, cancellationToken);
        await manager.DriverTransports.DeleteByIdAsync(driverTransport.DriverId, driverTransport.TransportId, cancellationToken);

        return Unit.Value;
    }
}