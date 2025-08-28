using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Route.Delete {
    public class DeleteRouteCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteRouteCommand, Unit> {
        public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken) {
            var route = await unitOfWork.Routes.GetByIdAsync(request.Id, cancellationToken)
                        ?? throw new NotFoundException(nameof(RouteEntity), request.Id);

            var assignments = await unitOfWork.RouteAssignments.GetAllByRouteIdAsync(route.Id, cancellationToken);

            if (assignments is not null && assignments.Any()) {
                foreach (var assignment in assignments) {
                    await unitOfWork.RouteAssignments.DeleteAsync(assignment, cancellationToken);
                }
            }

            await unitOfWork.Routes.DeleteAsync(route, cancellationToken);

            return Unit.Value;
        }
    }
}
