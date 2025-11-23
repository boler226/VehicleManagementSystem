using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.RegistrationRequst.Reject;
public class RejectRegistrationCommandHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<RejectRegistrationCommand, Unit>
{
    public async Task<Unit> Handle(RejectRegistrationCommand request, CancellationToken cancellationToken)
    {
        var regRequest = await repositoryManager.RegistrationRequest.GetByIdAsync(request.RequestId, cancellationToken);
        if (regRequest is null || regRequest.Status != "Pending")
            throw new Exception("Registration request not found or already processed");

        regRequest.Status = "Rejected";

        await repositoryManager.RegistrationRequest.UpdateAsync(regRequest, cancellationToken);

        return Unit.Value;
    }
}