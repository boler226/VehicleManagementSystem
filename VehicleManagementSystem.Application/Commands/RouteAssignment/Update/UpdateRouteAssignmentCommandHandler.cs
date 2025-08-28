using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Update {
    public class UpdateRouteAssignmentCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateRouteAssignmentCommand, Unit> {
        public async Task<Unit> Handle(UpdateRouteAssignmentCommand request, CancellationToken cancellationToken) {
            var assignment = await unitOfWork.RouteAssignments.GetByIdAsync(request.Id, cancellationToken)
                             ?? throw new NotFoundException(nameof(RouteAssignmentEntity), request.Id);

            if (request.TransportId.HasValue) {
                var transport = await unitOfWork.Transports.GetByIdAsync(request.TransportId.Value, cancellationToken)
                            ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

                assignment.TransportId = transport.Id;
                assignment.Transport = transport;
            }

            if (request.RouteId.HasValue)
            {
                var route = await unitOfWork.Routes.GetByIdAsync(request.RouteId.Value, cancellationToken)
                           ?? throw new NotFoundException(nameof(RouteEntity), request.RouteId);

                assignment.RouteId = route.Id;
                assignment.Route = route;
            }

            if (request.Date.HasValue)
                assignment.Date = request.Date.Value;

            if (request.PassengersCarried.HasValue)
                assignment.PassengersCarried = request.PassengersCarried.Value;

            await unitOfWork.RouteAssignments.UpdateAsync(assignment, cancellationToken);

            return Unit.Value;
        }
    }
}
