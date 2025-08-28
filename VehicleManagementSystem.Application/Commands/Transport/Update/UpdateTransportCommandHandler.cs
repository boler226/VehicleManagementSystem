using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Transport.Update {
    public class UpdateTransportCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateTransportCommand, Unit> {
        public async Task<Unit> Handle(UpdateTransportCommand request, CancellationToken cancellationToken) {
            var transport = await unitOfWork.Transports.GetByIdAsync(request.Id, cancellationToken)
                            ?? throw new NotFoundException(nameof(TransportEntity), request.Id);

            if (request.GarageId.HasValue) {
                var garage = await unitOfWork.GarageObjects.GetByIdAsync(request.GarageId.Value, cancellationToken)
                             ?? throw new NotFoundException(nameof(GarageObjectEntity), request.GarageId);

                transport.GarageObject = garage;
                transport.GarageObjectId = garage.Id;
            }

            if (!string.IsNullOrWhiteSpace(request.LicensePlate))
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
