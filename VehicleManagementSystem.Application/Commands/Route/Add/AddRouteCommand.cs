using MediatR;

namespace VehicleManagementSystem.Application.Commands.Route.Add {
    public record AddRouteCommand(string RouterNumber, string Description) : IRequest<Guid>;
}
