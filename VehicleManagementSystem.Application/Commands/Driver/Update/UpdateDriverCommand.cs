using MediatR;

namespace VehicleManagementSystem.Application.Commands.Driver.Update {
    public record UpdateDriverCommand(Guid Id, string? FullName, string? LicenseNumber, Guid? TeamId) : IRequest<Unit>;
}
