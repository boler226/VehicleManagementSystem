using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Technician.Delete {
    public class DeleteTechnicianCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteTechnicianCommand, Unit> {
        public async Task<Unit> Handle(DeleteTechnicianCommand request, CancellationToken cancellationToken) {
            var technician = await unitOfWork.Technicians.GetByIdAsync(request.Id, cancellationToken)
                             ?? throw new Exception("Technician not found");

            await unitOfWork.Technicians.DeleteAsync(technician, cancellationToken);

            return Unit.Value;
        }
    }
}
