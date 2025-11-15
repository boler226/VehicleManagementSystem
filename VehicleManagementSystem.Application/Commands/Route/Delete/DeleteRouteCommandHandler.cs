using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Route.Delete; 
public class DeleteRouteCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteRouteCommand, Unit> {
    public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken) {
        var route = await manager.Routes.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(RouteEntity), request.Id);

        var assignments = await manager.RouteAssignments.GetAllByRouteIdAsync(route.Id, cancellationToken);

        if (assignments is not null && assignments.Any()) {
            foreach (var assignment in assignments) {
                await manager.RouteAssignments.DeleteAsync(assignment, cancellationToken);
            }
        }

        await manager.Routes.DeleteAsync(route, cancellationToken);

        return Unit.Value;
    }
}
