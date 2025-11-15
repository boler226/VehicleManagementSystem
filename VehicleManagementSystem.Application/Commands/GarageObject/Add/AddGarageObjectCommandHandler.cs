using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Add; 
public class AddGarageObjectCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddGarageObjectCommand, Guid> {
    public async Task<Guid> Handle(AddGarageObjectCommand request, CancellationToken cancellationToken) {
        var garage = new GarageObjectEntity {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Location = request.Location
        };

        await manager.GarageObjects.AddAsync(garage, cancellationToken);

        return garage.Id;
    }
}
