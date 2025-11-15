using MediatR;
using VehicleManagementSystem.Application.DTOs.Team;

namespace VehicleManagementSystem.Application.Queries.Team.GetAll; 
public record GetAllTeamsQuery : IRequest<List<TeamDto>>;
