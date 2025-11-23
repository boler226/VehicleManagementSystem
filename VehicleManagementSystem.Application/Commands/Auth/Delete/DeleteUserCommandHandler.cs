using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Auth.Delete;
public class DeleteUserCommandHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repositoryManager.Users.GetByIdAsync(request.UserId, cancellationToken)
            ?? throw new NotFoundException(nameof(UserEntity), request.UserId);

        await repositoryManager.Users.DeleteAsync(user, cancellationToken);

        return Unit.Value;
    }
}
