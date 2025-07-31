using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Update {
    public class UpdateRepairWorkCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateRepairWorkCommand, Unit> {
        public async Task<Unit> Handle(UpdateRepairWorkCommand request, CancellationToken cancellationToken) {
            var work = await unitOfWork.RepairWorks.GetByIdAsync(request.Id, cancellationToken)
                       ?? throw new Exception("Repair work not found");

            if (!string.IsNullOrWhiteSpace(request.PartName))
                work.PartName = request.PartName;

            if (!string.IsNullOrWhiteSpace(request.WorkDescription))
                work.WorkDescription = request.WorkDescription;

            await unitOfWork.RepairWorks.UpdateAsync(work, cancellationToken);

            return Unit.Value;
        }
    }
}
