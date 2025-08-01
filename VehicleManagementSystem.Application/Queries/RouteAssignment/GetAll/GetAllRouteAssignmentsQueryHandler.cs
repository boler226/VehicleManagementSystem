using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.RouteAssignment;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.RouteAssignment.GetAll {
    public class GetAllRouteAssignmentsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllRouteAssignmentsQuery, List<RouteAssignmentDto>> {
        public async Task<List<RouteAssignmentDto>> Handle(GetAllRouteAssignmentsQuery request, CancellationToken cancellationToken) {
            var assignments = await unitOfWork.RouteAssignments.GetAllAsync(cancellationToken)
                              ?? throw new Exception("Route assignments does not exist");

            return mapper.Map<List<RouteAssignmentDto>>(assignments);
        }
    }
}
