using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Update; 
public class UpdateGarageObjectCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<UpdateGarageObjectCommand, Unit> {
    public async Task<Unit> Handle(UpdateGarageObjectCommand request, CancellationToken cancellationToken) {
        var garage = await manager.GarageObjects.GetByIdAsync(request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(GarageObjectEntity), request.Id);

        if (!string.IsNullOrWhiteSpace(request.Name)) 
            garage.Name = request.Name;

        if (!string.IsNullOrWhiteSpace(request.Location))
            garage.Location = request.Location;

        await manager.GarageObjects.UpdateAsync(garage, cancellationToken);

        return Unit.Value;
    }
}
