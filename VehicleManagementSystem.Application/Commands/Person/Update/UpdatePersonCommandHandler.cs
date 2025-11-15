using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Person.Update; 
public class UpdatePersonCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<UpdatePersonCommand, Unit> {
    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken) {
        var person = await manager.Persons.GetByIdAsync(request.Id ,cancellationToken)
                     ?? throw new NotFoundException(nameof(PersonEntity), request.Id);

        if (!string.IsNullOrWhiteSpace(request.FullName))
            person.FullName = request.FullName;

        if (!string.IsNullOrWhiteSpace(request.Position)) 
            person.Position = request.Position;

        await manager.Persons.UpdateAsync(person, cancellationToken);
        return Unit.Value;
    }
}
