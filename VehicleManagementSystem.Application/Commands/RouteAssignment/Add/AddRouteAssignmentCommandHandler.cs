using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Add; 
public class AddRouteAssignmentCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddRouteAssignmentCommand, Guid> {
    public async Task<Guid> Handle(AddRouteAssignmentCommand request, CancellationToken cancellationToken) {
        var transport = await manager.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                        ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

        var route = await manager.Routes.GetByIdAsync(request.RouteId, cancellationToken)
                    ?? throw new NotFoundException(nameof(RouteEntity), request.RouteId);

        var assignment = new RouteAssignmentEntity {
            Id = Guid.NewGuid(),
            Transport = transport,
            TransportId = transport.Id,
            Route = route,
            RouteId = route.Id,
            Date = request.Date,
            PassengersCarried = request.PassengersCarried
        };

        await manager.RouteAssignments.AddAsync(assignment, cancellationToken);

        return assignment.Id;
    }
}
