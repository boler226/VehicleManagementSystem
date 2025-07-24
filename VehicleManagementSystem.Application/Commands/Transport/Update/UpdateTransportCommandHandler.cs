using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Transport.Update {
    public class UpdateTransportCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateTransportCommand, Unit> {
        public async Task<Unit> Handle(UpdateTransportCommand request, CancellationToken cancellationToken) {
            var transport = await unitOfWork.Transports.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new Exception("Transport not found");

            if (request.LicensePlate is not null)
                transport.LicensePlate = request.LicensePlate;

            if (request.Type.HasValue)
                transport.Type = request.Type.Value;

            if (request.Capacity is not null)
                transport.Capacity = request.Capacity;

            if (request.LoadCapacity is not null)
                transport.LoadCapacity = request.LoadCapacity;

            await unitOfWork.Transports.UpdateAsync(transport, cancellationToken);
            return Unit.Value;
        }
    }
}
