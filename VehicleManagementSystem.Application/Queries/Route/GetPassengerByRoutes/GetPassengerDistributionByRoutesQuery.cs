using MediatR;
using VehicleManagementSystem.Application.DTOs.RouteAssignment;

namespace VehicleManagementSystem.Application.Queries.Route.GetByRoutes;
public record GetPassengerDistributionByRoutesQuery(DateTime? FromDate, DateTime? ToDate)
    : IRequest<IEnumerable<RoutePassengerDistributionDto>>;