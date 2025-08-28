using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Update {
    public class UpdateRepairWorkCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateRepairWorkCommand, Unit> {
        public async Task<Unit> Handle(UpdateRepairWorkCommand request, CancellationToken cancellationToken) {
            var work = await unitOfWork.RepairWorks.GetByIdAsync(request.Id, cancellationToken)
                       ?? throw new NotFoundException(nameof(RepairWorkEntity), request.Id);

            if (!string.IsNullOrWhiteSpace(request.PartName))
                work.PartName = request.PartName;

            if (!string.IsNullOrWhiteSpace(request.WorkDescription))
                work.WorkDescription = request.WorkDescription;

            await unitOfWork.RepairWorks.UpdateAsync(work, cancellationToken);

            return Unit.Value;
        }
    }
}
