using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Delete {
    public class DeleteRepairWorkCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteRepairWorkCommand, Unit> {
        public async Task<Unit> Handle(DeleteRepairWorkCommand request, CancellationToken cancellationToken) {
            var work = await unitOfWork.RepairWorks.GetByIdAsync(request.Id, cancellationToken)
                       ?? throw new Exception("Repair work not found");

            await unitOfWork.RepairWorks.DeleteAsync(work, cancellationToken);

            return Unit.Value;
        }
    }
}
