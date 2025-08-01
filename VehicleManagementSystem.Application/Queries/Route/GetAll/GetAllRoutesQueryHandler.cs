using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Route;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Route.GetAll {
    public class GetAllRoutesQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllRoutesQuery, List<RouteDto>> {
        public async Task<List<RouteDto>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken) {
            var routes = await unitOfWork.Routes.GetAllAsync(cancellationToken)
                         ?? throw new Exception("Routes does not exist");

            foreach (var route in routes) {
                var assignments = await unitOfWork.RouteAssignments.GetAllByRouteIdAsync(route.Id, cancellationToken);

                if (assignments is not null)
                    route.Assignments = assignments.ToList();
            }

            return mapper.Map<List<RouteDto>>(routes);
        }
    }
}
