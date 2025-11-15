using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Route;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Route.GetAll; 
public class GetAllRoutesQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllRoutesQuery, List<RouteDto>> {
    public async Task<List<RouteDto>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken) {
        var routes = await manager.Routes.GetAllAsync(cancellationToken);

        if (routes is not null) {
            foreach (var route in routes) {
                var assignments = await manager.RouteAssignments.GetAllByRouteIdAsync(route.Id, cancellationToken);

                if (assignments is not null)
                    route.Assignments = assignments.ToList();
            }
        }

        return mapper.Map<List<RouteDto>>(routes);
    }
}
