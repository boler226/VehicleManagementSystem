using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Delete {
    public class DeleteTransportRepairCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteTransportRepairCommand, Unit> {
        public async Task<Unit> Handle(DeleteTransportRepairCommand request, CancellationToken cancellationToken) {
            var repair = await unitOfWork.TransportRepairs.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new NotFoundException(nameof(TransportRepairEntity), request.Id);

            var works = await unitOfWork.RepairWorks.GetAllByRepairIdAsync(repair.Id, cancellationToken);

            if (works is not null && works.Any()) {
                foreach (var work in works ) 
                    await unitOfWork.RepairWorks.DeleteAsync(work, cancellationToken);
            }

            await unitOfWork.TransportRepairs.DeleteAsync(repair, cancellationToken);

            return Unit.Value;
        }
    }
}
