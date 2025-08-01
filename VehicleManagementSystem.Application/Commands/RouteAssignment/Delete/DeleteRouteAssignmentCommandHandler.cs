using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.RouteAssignment.Delete {
    public class DeleteRouteAssignmentCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteRouteAssignmentCommand, Unit> {
        public async Task<Unit> Handle(DeleteRouteAssignmentCommand request, CancellationToken cancellationToken) {
            var assignment = await unitOfWork.RouteAssignments.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new Exception("Route assignment not found");

            await unitOfWork.RouteAssignments.DeleteAsync(assignment, cancellationToken);

            return Unit.Value;
        }
    }
}
