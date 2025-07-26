using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Team.Add {
    public class AddTeamCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddTeamCommand, Guid> {
        public async Task<Guid> Handle(AddTeamCommand request, CancellationToken cancellationToken) {
            var personRoles = new Dictionary<string, Guid?> {
                { "Foreman", request.ForemanId },
                { "Master", request.MasterId },
                { "SectionHead", request.SectionHeadId },
                { "WorkshopHead", request.WorkshopHeadId }
            };

            foreach ( var role in personRoles) {
                if (role.Value.HasValue) {
                    var person = await unitOfWork.Persons.GetByIdAsync(role.Value.Value, cancellationToken)
                                 ?? throw new Exception($"{role.Key} with ID {role.Value.Value} not found");
                }
            }

            var team = new TeamEntity {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ForemanId = request.ForemanId,
                MasterId = request.MasterId,
                SectionHeadId = request.SectionHeadId,
                WorkshopHeadId = request.WorkshopHeadId
            };

            await unitOfWork.Teams.AddAsync(team, cancellationToken);

            return team.Id;
        }
    }
}
