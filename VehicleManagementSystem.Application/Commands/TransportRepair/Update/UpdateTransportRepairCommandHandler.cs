using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Update {
    public class UpdateTransportRepairCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateTransportRepairCommand, Unit> {
        public async Task<Unit> Handle(UpdateTransportRepairCommand request, CancellationToken cancellationToken) {
            var repair = await unitOfWork.TransportRepairs.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new Exception("Repair not found");

            if (request.GarageId.HasValue) {
                var garage = await unitOfWork.GarageObjects.GetByIdAsync(request.GarageId.Value, cancellationToken)
                             ?? throw new Exception("Garage object not found");

                repair.GarageObject = garage;
                repair.GarageObjectId = garage.Id;
            }

            if (request.RepairDate.HasValue) 
                repair.RepairDate = request.RepairDate.Value;

            if (request.Cost.HasValue) 
                repair.Cost = request.Cost.Value;

            await unitOfWork.TransportRepairs.UpdateAsync(repair, cancellationToken);

            return Unit.Value;
        }
    }
}
