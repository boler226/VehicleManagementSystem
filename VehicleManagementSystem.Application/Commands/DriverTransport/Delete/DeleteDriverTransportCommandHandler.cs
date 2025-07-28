using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.DriverTransport.Delete {
    public class DeleteDriverTransportCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteDriverTransportCommand, Unit> {
        public async Task<Unit> Handle(DeleteDriverTransportCommand request, CancellationToken cancellationToken) {
            var driverTransport = await unitOfWork.DriverTransports.GetByIdAsync(request.driverId, request.transportId, cancellationToken)
                                  ?? throw new Exception("DriverTransport does not exist");

            await unitOfWork.DriverTransports.DeleteByIdAsync(request.driverId, request.transportId, cancellationToken);

            return Unit.Value;
        }
    }
}
