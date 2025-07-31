using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Person.Delete {
    public class DeletePersonCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeletePersonCommand, Unit> {
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken) {
            var person = await unitOfWork.Persons.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new Exception("Person not found");

            await unitOfWork.Persons.DeleteAsync(person, cancellationToken);

            var team = await unitOfWork.Teams.GetByPersonIdAsync(request.Id, cancellationToken);

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
                        await unitOfWork.Teams.UpdateAsync(team, cancellationToken);
                        break;
                    }
                }
            }

            return Unit.Value;
        }
    }
}
