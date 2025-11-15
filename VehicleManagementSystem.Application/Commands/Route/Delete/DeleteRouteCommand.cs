using MediatR;

namespace VehicleManagementSystem.Application.Commands.Route.Delete; 
public record DeleteRouteCommand(Guid Id) : IRequest<Unit>;
