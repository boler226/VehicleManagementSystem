using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Delete; 
public class DeleteRepairWorkCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteRepairWorkCommand, Unit> {
    public async Task<Unit> Handle(DeleteRepairWorkCommand request, CancellationToken cancellationToken) {
        var work = await manager.RepairWorks.GetByIdAsync(request.Id, cancellationToken)
                   ?? throw new NotFoundException(nameof(RepairWorkEntity), request.Id);

        await manager.RepairWorks.DeleteAsync(work, cancellationToken);

        return Unit.Value;
    }
}
