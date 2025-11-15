using MediatR;
using VehicleManagementSystem.Application.DTOs.RouteAssignment;

namespace VehicleManagementSystem.Application.Queries.RouteAssignment.GetAll; 
public record GetAllRouteAssignmentsQuery : IRequest<List<RouteAssignmentDto>>;
