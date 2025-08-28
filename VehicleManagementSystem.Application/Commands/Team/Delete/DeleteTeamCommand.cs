using MediatR;

namespace VehicleManagementSystem.Application.Commands.Team.Delete {
    public record DeleteTeamCommand(Guid Id) : IRequest<Unit>;
}
