using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.DriverTransport.Add; 
public class AddDriverTransportCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddDriverTransportCommand, Unit> {
    public async Task<Unit> Handle(AddDriverTransportCommand request, CancellationToken cancellationToken) {
        var driver = await manager.Drivers.GetByIdAsync(request.DriverId, cancellationToken)
                     ?? throw new NotFoundException(nameof(DriverEntity), request.DriverId);

        var transport = await manager.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                        ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

        var driverTransport = new DriverTransportEntity {
            DriverId = driver.Id,
            TransportId = transport.Id,
            Driver = driver,
            Transport = transport
        };

        await manager.DriverTransports.AddAsync(driverTransport, cancellationToken);

        return Unit.Value;
    }
}
