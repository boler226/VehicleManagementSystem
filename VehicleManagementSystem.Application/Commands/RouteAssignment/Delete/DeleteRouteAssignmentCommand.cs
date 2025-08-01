using MediatR;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Delete {
    public record DeleteRouteAssignmentCommand(Guid Id) : IRequest<Unit>;
}
