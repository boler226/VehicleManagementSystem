using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Delete; 
public class DeleteTransportRepairCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteTransportRepairCommand, Unit> {
    public async Task<Unit> Handle(DeleteTransportRepairCommand request, CancellationToken cancellationToken) {
        var repair = await manager.TransportRepairs.GetByIdAsync(request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(TransportRepairEntity), request.Id);

        var works = await manager.RepairWorks.GetAllByRepairIdAsync(repair.Id, cancellationToken);

        if (works is not null && works.Any()) {
            foreach (var work in works ) 
                await manager.RepairWorks.DeleteAsync(work, cancellationToken);
        }

        await manager.TransportRepairs.DeleteAsync(repair, cancellationToken);

        return Unit.Value;
    }
}
