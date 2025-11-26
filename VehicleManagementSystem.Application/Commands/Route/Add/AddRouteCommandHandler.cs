using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Route.Add; 
public class AddRouteCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddRouteCommand, Guid> {
    public async Task<Guid> Handle(AddRouteCommand request, CancellationToken cancellationToken) {
        var route = new RouteEntity {
            Id = Guid.NewGuid(),
            RouteNumber = request.RouteNumber,
            Description = request.Description
           
        };

        await manager.Routes.AddAsync(route, cancellationToken);

        return route.Id;
    }
}
