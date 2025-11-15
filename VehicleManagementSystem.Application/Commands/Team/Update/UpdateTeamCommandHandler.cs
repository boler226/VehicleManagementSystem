using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Team.Update; 
public class UpdateTeamCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<UpdateTeamCommand, Unit> {
    public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken) {
        var team = await manager.Teams.GetByIdAsync(request.Id, cancellationToken)
                   ?? throw new NotFoundException(nameof(TeamEntity), request.Id);

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
                var person = await manager.Persons.GetByIdAsync(personId.Value, cancellationToken)
                             ?? throw new NotFoundException(role, personId);

                roleSetters[role](person);
            }
        }

        if (request.Name is not null) 
            team.Name = request.Name;

        await manager.Teams.UpdateAsync(team, cancellationToken);

        return Unit.Value;
    }
}