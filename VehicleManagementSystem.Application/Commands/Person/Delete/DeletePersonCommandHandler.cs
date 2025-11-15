using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Person.Delete; 
public class DeletePersonCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeletePersonCommand, Unit> {
    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken) {
        var person = await manager.Persons.GetByIdAsync(request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(PersonEntity), request.Id);

        await manager.Persons.DeleteAsync(person, cancellationToken);

        var team = await manager.Teams.GetByPersonIdAsync(request.Id, cancellationToken);

        if (team is not null) {

            var roleMap = new (Func<TeamEntity, Guid?> GetId, Action<TeamEntity> Clear)[] {
               (t => t.ForemanId,       t => { t.ForemanId = null; t.Foreman = null; }),
               (t => t.MasterId,        t => { t.MasterId = null; t.Master = null; }),
               (t => t.SectionHeadId,   t => { t.SectionHeadId = null; t.SectionHead = null; }),
               (t => t.WorkshopHeadId,  t => { t.WorkshopHeadId = null; t.WorkshopHead = null; })
            };

            foreach (var (getId, clear) in roleMap) {
                if (getId(team) == person.Id) {
                    clear(team);
                    await manager.Teams.UpdateAsync(team, cancellationToken);
                }
            }
        }

        return Unit.Value;
    }
}
