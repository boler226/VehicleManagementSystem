using MediatR;
using VehicleManagementSystem.Application.DTOs.Auth;
using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.Application.Queries.Auth.GetAll;
public record GetAllUsersCommand : IRequest<List<UserDto>>;