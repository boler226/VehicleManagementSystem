using MediatR;

namespace VehicleManagementSystem.Application.Commands.Auth.Delete;
public record DeleteUserCommand(Guid UserId) : IRequest<Unit>;