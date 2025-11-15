using MediatR;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Add; 
public record AddRouteAssignmentCommand(Guid TransportId, Guid RouteId, DateTime Date, int PassengersCarried) : IRequest<Guid>;
