using MediatR;
using VehicleManagementSystem.Application.DTOs.Auth;

namespace VehicleManagementSystem.Application.Queries.Auth.GetAll;
public record GetAllUsersCommand : IRequest<List<UserDto>>;