using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Technician.Delete {
    public class DeleteTechnicianCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteTechnicianCommand, Unit> {
        public async Task<Unit> Handle(DeleteTechnicianCommand request, CancellationToken cancellationToken) {
            var technician = await unitOfWork.Technicians.GetByIdAsync(request.Id, cancellationToken)
                             ?? throw new NotFoundException(nameof(TechnicianEntity), request.Id);

            await unitOfWork.Technicians.DeleteAsync(technician, cancellationToken);

            return Unit.Value;
        }
    }
}
