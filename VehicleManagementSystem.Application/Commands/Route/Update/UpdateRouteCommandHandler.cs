using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Route.Update; 
public class UpdateRouteCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<UpdateRouteCommand, Unit> {
    public async Task<Unit> Handle(UpdateRouteCommand request, CancellationToken cancellationToken) {
        var route = await manager.Routes.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(RouteEntity), request.Id);

        if (!string.IsNullOrWhiteSpace(request.RouterNumber))
            route.RouterNumber = request.RouterNumber;

        if (!string.IsNullOrWhiteSpace(request.Description))
            route.Description = request.Description;

        await manager.Routes.UpdateAsync(route, cancellationToken);

        return Unit.Value;
    }
}
