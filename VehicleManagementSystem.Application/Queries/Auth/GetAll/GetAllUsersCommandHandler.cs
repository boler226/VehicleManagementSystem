using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Auth;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Auth.GetAll;
public class GetAllUsersCommandHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    ) : IRequestHandler<GetAllUsersCommand, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        var users = await repositoryManager.Users.GetAllAsync(cancellationToken);

        return mapper.Map<List<UserDto>>(users);
    }
}