using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.RegistrationRequst.GetAll;
public class GetAllRegistrationRequestQueryHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<GetAllRegistrationRequestQuery, List<RegistrationRequest>>
{
    public async Task<List<RegistrationRequest>> Handle(GetAllRegistrationRequestQuery request, CancellationToken cancellationToken)
    {
        return await repositoryManager.RegistrationRequest.GetAllAsync(cancellationToken);
    }
}