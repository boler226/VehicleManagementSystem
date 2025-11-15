using MediatR;

namespace VehicleManagementSystem.Application.Commands.Route.Update; 
public record UpdateRouteCommand(Guid Id, string? RouterNumber, string? Description) : IRequest<Unit>;
