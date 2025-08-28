using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.DriverTransport.Delete {
    public class DeleteDriverTransportCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteDriverTransportCommand, Unit> {
        public async Task<Unit> Handle(DeleteDriverTransportCommand request, CancellationToken cancellationToken) {
            var driverTransport = await unitOfWork.DriverTransports.GetByIdAsync(request.driverId, request.transportId, cancellationToken)
                                  ?? throw new NotFoundException(nameof(DriverEntity) + " or " + nameof(TransportEntity), request.driverId + " or " + request.transportId);

            await unitOfWork.DriverTransports.DeleteByIdAsync(driverTransport.DriverId, driverTransport.TransportId, cancellationToken);

            return Unit.Value;
        }
    }
}
