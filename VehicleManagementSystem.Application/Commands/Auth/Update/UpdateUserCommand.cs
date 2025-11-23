using MediatR;

namespace VehicleManagementSystem.Application.Commands.Auth.Update;
public record UpdateUserCommand(
    Guid UserId,
    string UserName,
    string Email,
    string FullName,
    string Role
) : IRequest<Unit>;