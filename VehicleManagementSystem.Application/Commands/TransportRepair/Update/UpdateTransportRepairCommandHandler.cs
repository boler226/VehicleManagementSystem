using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Update; 
public class UpdateTransportRepairCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<UpdateTransportRepairCommand, Unit> {
    public async Task<Unit> Handle(UpdateTransportRepairCommand request, CancellationToken cancellationToken) {
        var repair = await manager.TransportRepairs.GetByIdAsync(request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(TransportRepairEntity), request.Id);

        if (request.GarageId.HasValue) {
            var garage = await manager.GarageObjects.GetByIdAsync(request.GarageId.Value, cancellationToken)
                         ?? throw new NotFoundException(nameof(GarageObjectEntity), request.GarageId);

            repair.GarageObject = garage;
            repair.GarageObjectId = garage.Id;
        }

        if (request.RepairDate.HasValue) 
            repair.RepairDate = request.RepairDate.Value;

        if (request.Cost.HasValue) 
            repair.Cost = request.Cost.Value;

        await manager.TransportRepairs.UpdateAsync(repair, cancellationToken);

        return Unit.Value;
    }
}