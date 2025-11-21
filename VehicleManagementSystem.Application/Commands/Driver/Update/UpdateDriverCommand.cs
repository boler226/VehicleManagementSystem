using MediatR;

namespace VehicleManagementSystem.Application.Commands.Driver.Update; 
public record UpdateDriverCommand(Guid Id, string? FullName, Guid? TeamId) : IRequest<Unit>;
