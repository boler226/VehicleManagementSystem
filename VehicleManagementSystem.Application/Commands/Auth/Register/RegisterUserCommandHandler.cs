using System.Net;
using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Enums.Identity;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Auth.Register;
public class RegisterUserCommandHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Role == UserRoles.AdminSD)
        {
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = UserRoles.AdminSD
            };

            await repositoryManager.Users.AddAsync(user, cancellationToken);
            return user.Id;
        } 
        else
        {
            var regRequest = new RegistrationRequest
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                Status = "Pending"
            };

            await repositoryManager.RegistrationRequest.AddAsync(regRequest, cancellationToken);
            return regRequest.Id;
        }
    }
}