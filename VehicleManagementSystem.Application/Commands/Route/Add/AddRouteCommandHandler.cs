using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Route.Add {
    public class AddRouteCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddRouteCommand, Guid> {
        public async Task<Guid> Handle(AddRouteCommand request, CancellationToken cancellationToken) {
            var route = new RouteEntity {
                Id = Guid.NewGuid(),
                RouterNumber = request.RouterNumber,
                Description = request.Description
               
            };

            await unitOfWork.Routes.AddAsync(route, cancellationToken);

            return route.Id;
        }
    }
}
