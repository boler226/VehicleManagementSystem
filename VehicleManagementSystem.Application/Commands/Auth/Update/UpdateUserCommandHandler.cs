using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Auth.Update;
public class UpdateUserCommandHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repositoryManager.Users.GetByIdAsync(request.UserId, cancellationToken)
            ?? throw new NotFoundException(nameof(UserEntity), request.UserId);

        user.UserName = request.UserName;
        user.Email = request.Email;
        user.FullName = request.FullName;
        user.Role = request.Role;

        await repositoryManager.Users.UpdateAsync(user, cancellationToken);
        return Unit.Value;
    }
}
