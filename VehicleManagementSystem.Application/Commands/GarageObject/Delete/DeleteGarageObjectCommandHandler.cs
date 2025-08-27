using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Delete {
    public class DeleteGarageObjectCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteGarageObjectCommand, Unit> {
        public async Task<Unit> Handle(DeleteGarageObjectCommand reqeust, CancellationToken cancellationToken) {
            var garage = await unitOfWork.GarageObjects.GetByIdAsync(reqeust.Id, cancellationToken)
                         ?? throw new Exception("GarageObject not found");

            var transports = await unitOfWork.Transports.GetAllByGarageIdAsync(reqeust.Id, cancellationToken);

            if (transports is not null) {
                foreach (var transport in transports) {
                    transport.GarageObject = null;
                    transport.GarageObjectId = null;

                    await unitOfWork.Transports.UpdateAsync(transport, cancellationToken);
                }
            }

            var transportReparis = await unitOfWork.TransportRepairs.GetAllByGarageIdAsync(reqeust.Id, cancellationToken);

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
