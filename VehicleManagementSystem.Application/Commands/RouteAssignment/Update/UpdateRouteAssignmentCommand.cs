using MediatR;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Update {
    public record UpdateRouteAssignmentCommand(Guid Id, Guid? TransportId, Guid? RouteId, DateTime? Date, int? PassengersCarried) : IRequest<Unit>;
}
