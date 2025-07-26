using MediatR;

namespace VehicleManagementSystem.Application.Commands.Person.Add {
    public record AddPersonCommand(string FullName, string Position) : IRequest<Guid>;
}
