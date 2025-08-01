using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Add {
    public class AddRouteAssignmentCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddRouteAssignmentCommand, Guid> {
        public async Task<Guid> Handle(AddRouteAssignmentCommand request, CancellationToken cancellationToken) {
            var transport = await unitOfWork.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                            ?? throw new Exception("Transport not found");

            var route = await unitOfWork.Routes.GetByIdAsync(request.RouteId, cancellationToken)
                        ?? throw new Exception("Route not found");

            var assignment = new RouteAssignmentEntity {
                Id = Guid.NewGuid(),
                Transport = transport,
                TransportId = transport.Id,
                Route = route,
                RouteId = route.Id,
                Date = request.Date,
                PassengersCarried = request.PassengersCarried
            };

            await unitOfWork.RouteAssignments.AddAsync(assignment, cancellationToken);

            return assignment.Id;
        }
    }
}
