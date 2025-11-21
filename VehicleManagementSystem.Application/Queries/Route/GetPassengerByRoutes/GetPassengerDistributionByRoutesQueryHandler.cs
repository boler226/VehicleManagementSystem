using MediatR;
using VehicleManagementSystem.Application.DTOs.RouteAssignment;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Route.GetByRoutes;
public class GetPassengerDistributionByRoutesQueryHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<GetPassengerDistributionByRoutesQuery, IEnumerable<RoutePassengerDistributionDto>>
{
    public async Task<IEnumerable<RoutePassengerDistributionDto>> Handle(
        GetPassengerDistributionByRoutesQuery request,
        CancellationToken cancellationToken)
    {
        var assignments = await repositoryManager.RouteAssignments.GetAssignmentsAsync(request.FromDate, request.ToDate, cancellationToken);

        var grouped = assignments
            .GroupBy(x => x.RouteId)
            .Select(g =>
            {
                var route = repositoryManager.Routes.GetByIdAsync(g.Key, cancellationToken).Result;

                return new RoutePassengerDistributionDto
                {
                    RouteId = g.Key,
                    RouteNumber = route?.RouterNumber ?? "Unknown",
                    Description = route?.Description ?? string.Empty,
                    TotalPassengers = g.Sum(x => x.PassengersCarried)
                };
            });

        return grouped;
    }
}
