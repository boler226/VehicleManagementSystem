using MediatR;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Delete {
    public record DeleteGarageObjectCommand(Guid Id) : IRequest<Unit>;
}
