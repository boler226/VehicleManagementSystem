using MediatR;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Update {
    public record UpdateGarageObjectCommand(Guid Id, string? Name, string? Location) : IRequest<Unit>;
}
