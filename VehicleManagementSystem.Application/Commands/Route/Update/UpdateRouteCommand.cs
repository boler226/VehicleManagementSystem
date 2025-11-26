using MediatR;

namespace VehicleManagementSystem.Application.Commands.Route.Update; 
public record UpdateRouteCommand(Guid Id, string? RouteNumber, string? Description) : IRequest<Unit>;
