using MediatR;

namespace VehicleManagementSystem.Application.Commands.Person.Delete {
    public record DeletePersonCommand(Guid Id) : IRequest<Unit>;
}
