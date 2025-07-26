using MediatR;

namespace VehicleManagementSystem.Application.Commands.Technician.Delete {
    public record DeleteTechnicianCommand(Guid Id) : IRequest<Unit>;
}