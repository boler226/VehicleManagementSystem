using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Team.Add {
    public class AddTeamCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddTeamCommand, Guid> {
        public async Task<Guid> Handle(AddTeamCommand request, CancellationToken cancellationToken) {
            var team = new TeamEntity {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };

            var roleSetters = new Dictionary<string, Action<PersonEntity>> {
                { "Foreman", p => { team.Foreman = p; team.ForemanId = p.Id; } },
                { "Master", p => { team.Master = p; team.MasterId = p.Id; } },
                { "SectionHead", p => { team.SectionHead = p; team.SectionHeadId = p.Id; } },
                { "WorkshopHead", p => { team.WorkshopHead = p; team.WorkshopHeadId = p.Id; } }
            };

            var personRoles = new Dictionary<string, Guid?> {
                { "Foreman", request.ForemanId },
                { "Master", request.MasterId },
                { "SectionHead", request.SectionHeadId },
                { "WorkshopHead", request.WorkshopHeadId }
            };

            foreach (var (role, personId) in personRoles) {
                if (personId.HasValue) {
                    var person = await unitOfWork.Persons.GetByIdAsync(personId.Value, cancellationToken)
                                 ?? throw new Exception($"{role} with ID {personId.Value} not found");

                    roleSetters[role](person);
                }
            }

            await unitOfWork.Teams.AddAsync(team, cancellationToken);

            return team.Id;
        }
    }
}
