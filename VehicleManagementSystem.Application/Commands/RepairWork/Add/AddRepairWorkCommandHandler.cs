using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Add {
    public class AddRepairWorkCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddRepairWorkCommand, Guid> {
        public async Task<Guid> Handle(AddRepairWorkCommand request, CancellationToken cancellationToken) {
            var technician = await unitOfWork.Technicians.GetByIdAsync(request.TechnicianId, cancellationToken)
                             ?? throw new NotFoundException(nameof(TechnicianEntity), request.TechnicianId);

            var repair = await unitOfWork.TransportRepairs.GetByIdAsync(request.RepairId, cancellationToken)
                         ?? throw new NotFoundException(nameof(RepairWorkEntity), request.RepairId);

            var work = new RepairWorkEntity {
                Id = Guid.NewGuid(),
                Technician = technician,
                TechnicianId = request.TechnicianId,
                Repair = repair,
                RepairId = request.RepairId,
                PartName = request.PartName,
                WorkDescription = request.WorkDescription
            };

            await unitOfWork.RepairWorks.AddAsync(work, cancellationToken);

            return work.Id;
        }
    }
}
