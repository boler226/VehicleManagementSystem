using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Delete; 
public class DeleteGarageObjectCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteGarageObjectCommand, Unit> {
    public async Task<Unit> Handle(DeleteGarageObjectCommand request, CancellationToken cancellationToken) {
        var garage = await manager.GarageObjects.GetByIdAsync(request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(GarageObjectEntity), request.Id);

        var transports = await manager.Transports.GetAllByGarageIdAsync(request.Id, cancellationToken);

        if (transports is not null) {
            foreach (var transport in transports) {
                transport.GarageObject = null;
                transport.GarageObjectId = null;

                await manager.Transports.UpdateAsync(transport, cancellationToken);
            }
        }

        var transportReparis = await manager.TransportRepairs.GetAllByGarageIdAsync(request.Id, cancellationToken);

        if (transportReparis is not null) {
            foreach(var repairs in transportReparis) {
                repairs.GarageObject = null;
                repairs.GarageObjectId = null;

                await manager.TransportRepairs.UpdateAsync(repairs, cancellationToken);
            }
        }

        await manager.GarageObjects.DeleteAsync(garage, cancellationToken);

        return Unit.Value;
    }
}
