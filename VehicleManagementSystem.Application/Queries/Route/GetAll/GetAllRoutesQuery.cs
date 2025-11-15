using MediatR;
using VehicleManagementSystem.Application.DTOs.Route;

namespace VehicleManagementSystem.Application.Queries.Route.GetAll; 
public record GetAllRoutesQuery : IRequest<List<RouteDto>>;
