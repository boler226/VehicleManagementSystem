using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Delete {
    public class DeleteRepairWorkCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteRepairWorkCommand, Unit> {
        public async Task<Unit> Handle(DeleteRepairWorkCommand request, CancellationToken cancellationToken) {
            var work = await unitOfWork.RepairWorks.GetByIdAsync(request.Id, cancellationToken)
                       ?? throw new NotFoundException(nameof(RepairWorkEntity), request.Id);

            await unitOfWork.RepairWorks.DeleteAsync(work, cancellationToken);

            return Unit.Value;
        }
    }
}
