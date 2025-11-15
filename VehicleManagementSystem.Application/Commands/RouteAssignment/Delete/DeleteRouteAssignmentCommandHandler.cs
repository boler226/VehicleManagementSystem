using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Delete; 
public class DeleteRouteAssignmentCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteRouteAssignmentCommand, Unit> {
    public async Task<Unit> Handle(DeleteRouteAssignmentCommand request, CancellationToken cancellationToken) {
        var assignment = await manager.RouteAssignments.GetByIdAsync(request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(RouteAssignmentEntity), request.Id);

        await manager.RouteAssignments.DeleteAsync(assignment, cancellationToken);

        return Unit.Value;
    }
}
