using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Add {
    public class AddTransportRepairCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddTransportRepairCommand, Guid> {
        public async Task<Guid> Handle(AddTransportRepairCommand request, CancellationToken cancellationToken) {
            var transport = await unitOfWork.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                            ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

            var repair = new TransportRepairEntity {
                Id = Guid.NewGuid(),
                TransportId = request.TransportId,
                Transport = transport,
                RepairDate = DateTime.UtcNow,
                Cost = request.Cost
            };

            if (request.GarageId is not null) {
                var garage = await unitOfWork.GarageObjects.GetByIdAsync(request.GarageId.Value, cancellationToken)
                             ?? throw new NotFoundException(nameof(GarageObjectEntity), request.GarageId);

                repair.GarageObject = garage;
                repair.GarageObjectId = garage.Id;
            }

            await unitOfWork.TransportRepairs.AddAsync(repair, cancellationToken);

            return repair.Id;
        }
    }
}
