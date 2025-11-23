using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Enums.Identity;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.RegistrationRequst.Approve;
public class ApproveRegistrationCommandHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<ApproveRegistrationCommand, Guid>
{
    public async Task<Guid> Handle(ApproveRegistrationCommand request, CancellationToken cancellationToken)
    {
        var regRequest = await repositoryManager.RegistrationRequest.GetByIdAsync(request.RequestId, cancellationToken);
        if (regRequest is null || regRequest.Status != "Pending")
            throw new Exception("Registration request not found or already processed");

        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = regRequest.Email,
            Email = regRequest.Email,
            FullName = regRequest.FullName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(regRequest.Password),
            Role = UserRoles.Authorized
        };

        await repositoryManager.Users.AddAsync(user, cancellationToken);

        regRequest.Status = "Approved";
        await repositoryManager.RegistrationRequest.UpdateAsync(regRequest, cancellationToken);

        return user.Id;
    }
}