using MediatR;

namespace VehicleManagementSystem.Application.Commands.Route.Add; 
public record AddRouteCommand(string RouteNumber, string Description) : IRequest<Guid>;
