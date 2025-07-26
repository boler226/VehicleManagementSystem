using MediatR;

namespace VehicleManagementSystem.Application.Commands.Technician.Update {
    public record UpdateTechnicianCommand(Guid Id, string? FullName, string? Speciality, Guid? TeamId) : IRequest<Unit>;
}
