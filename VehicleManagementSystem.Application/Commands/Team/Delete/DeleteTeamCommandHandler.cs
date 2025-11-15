using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Team.Delete; 
public class DeleteTeamCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteTeamCommand, Unit> {
    public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken) {
        var team = await manager.Teams.GetByIdAsync(request.Id, cancellationToken)
                   ?? throw new NotFoundException(nameof(TeamEntity), request.Id);

        await manager.Teams.DeleteAsync(team, cancellationToken);
        
        return Unit.Value;
    }
}
