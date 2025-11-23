using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Auth.Register;
public class RegisterUserCommandHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
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