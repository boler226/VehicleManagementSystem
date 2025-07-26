using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Person.Update {
    public class UpdatePersonCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdatePersonCommand, Unit> {
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken) {
            var person = await unitOfWork.Persons.GetByIdAsync(request.Id ,cancellationToken)
                         ?? throw new Exception("Person not found");

            if (!string.IsNullOrWhiteSpace(request.FullName))
                person.FullName = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.Position)) 
                person.Position = request.Position;

            await unitOfWork.Persons.UpdateAsync(person, cancellationToken);
            return Unit.Value;
        }
    }
}
