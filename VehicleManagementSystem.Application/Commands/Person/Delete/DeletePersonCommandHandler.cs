using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Person.Delete {
    public class DeletePersonCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeletePersonCommand, Unit> {
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken) {
            var person = await unitOfWork.Persons.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new Exception("Person not found");

            // realize UpdateTeam!
            await unitOfWork.Persons.DeleteAsync(person, cancellationToken);
            return Unit.Value;
        }
    }
}
