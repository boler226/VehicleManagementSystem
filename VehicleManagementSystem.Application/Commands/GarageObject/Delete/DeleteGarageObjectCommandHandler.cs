using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Delete {
    public class DeleteGarageObjectCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteGarageObjectCommand, Unit> {
        public async Task<Unit> Handle(DeleteGarageObjectCommand request, CancellationToken cancellationToken) {
            var garage = await unitOfWork.GarageObjects.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new NotFoundException(nameof(GarageObjectEntity), request.Id);

            var transports = await unitOfWork.Transports.GetAllByGarageIdAsync(request.Id, cancellationToken);

            if (transports is not null) {
                foreach (var transport in transports) {
                    transport.GarageObject = null;
                    transport.GarageObjectId = null;

                    await unitOfWork.Transports.UpdateAsync(transport, cancellationToken);
                }
            }

            var transportReparis = await unitOfWork.TransportRepairs.GetAllByGarageIdAsync(request.Id, cancellationToken);

            if (transportReparis is not null) {
                foreach(var repairs in transportReparis) {
                    repairs.GarageObject = null;
                    repairs.GarageObjectId = null;

                    await unitOfWork.TransportRepairs.UpdateAsync(repairs, cancellationToken);
                }
            }

            await unitOfWork.GarageObjects.DeleteAsync(garage, cancellationToken);

            return Unit.Value;
        }
    }
}
