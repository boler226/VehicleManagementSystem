using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.DriverTransport.Add {
    public class AddDriverTransportCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddDriverTransportCommand, Unit> {
        public async Task<Unit> Handle(AddDriverTransportCommand request, CancellationToken cancellationToken) {
            var driver = await unitOfWork.Drivers.GetByIdAsync(request.DriverId, cancellationToken)
                         ?? throw new NotFoundException(nameof(DriverEntity), request.DriverId);

            var transport = await unitOfWork.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                            ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

            var driverTransport = new DriverTransportEntity {
                DriverId = driver.Id,
                TransportId = transport.Id,
                Driver = driver,
                Transport = transport
            };

            await unitOfWork.DriverTransports.AddAsync(driverTransport, cancellationToken);

            return Unit.Value;
        }
    }
}
