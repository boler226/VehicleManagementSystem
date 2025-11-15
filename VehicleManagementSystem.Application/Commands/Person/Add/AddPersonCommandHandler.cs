using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Person.Add; 
public class AddPersonCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddPersonCommand, Guid> {
    public async Task<Guid> Handle(AddPersonCommand request, CancellationToken cancellationToken) {
        var person = new PersonEntity {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Position = request.Position
        };

        await manager.Persons.AddAsync(person, cancellationToken);
        return person.Id;
    }
}
