using MediatR;

namespace VehicleManagementSystem.Application.Commands.Person.Update {
    public record UpdatePersonCommand(Guid Id, string? FullName, string? Position) : IRequest<Unit>;
}
