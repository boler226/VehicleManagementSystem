using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Team.Delete {
    public class DeleteTeamCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteTeamCommand, Unit> {
        public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken) {
            var team = await unitOfWork.Teams.GetByIdAsync(request.id, cancellationToken)
                       ?? throw new Exception("Team not found");

            await unitOfWork.Teams.DeleteAsync(team, cancellationToken);
            
            return Unit.Value;
        }
    }
}
