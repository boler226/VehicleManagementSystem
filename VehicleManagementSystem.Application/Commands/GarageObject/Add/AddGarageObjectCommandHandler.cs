using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Add {
    public class AddGarageObjectCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddGarageObjectCommand, Guid> {
        public async Task<Guid> Handle(AddGarageObjectCommand request, CancellationToken cancellationToken) {
            var garage = new GarageObjectEntity {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Location = request.Location
            };

            await unitOfWork.GarageObjects.AddAsync(garage, cancellationToken);

            return garage.Id;
        }
    }
}
