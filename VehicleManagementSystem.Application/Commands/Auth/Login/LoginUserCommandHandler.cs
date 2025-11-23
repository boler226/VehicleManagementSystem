using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Domain.Interfaces.Identity;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Auth.Login;
public class LoginUserCommandHandler(
    IRepositoryManager repositoryManager,
    IJwtTokenService tokenService
    ) : IRequestHandler<LoginUserCommand, string>
{
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repositoryManager.Users.GetByEmailAsync(request.Email, cancellationToken)
            ?? throw new NotFoundException(nameof(UserEntity), request.Email);

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        return tokenService.GenerateToken(user);
    }
}