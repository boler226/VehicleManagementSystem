using MediatR;

namespace VehicleManagementSystem.Application.Commands.Auth.Register;
public record RegisterUserCommand(
    string UserName,
    string Email,
    string Password,
    string FullName,
    string Role
) : IRequest<Guid>;