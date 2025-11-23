using MediatR;

namespace VehicleManagementSystem.Application.Commands.Auth.Login;
public record LoginUserCommand(
    string Email,
    string Password
) : IRequest<string>;