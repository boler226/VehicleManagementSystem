using MediatR;

namespace VehicleManagementSystem.Application.Commands.Driver.Add {
    public record AddDriverCommand(string FullName, string LicenseNumber, Guid TeamId) : IRequest<Guid>;
}
