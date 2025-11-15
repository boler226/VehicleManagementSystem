using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Technician.Delete; 
public class DeleteTechnicianCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteTechnicianCommand, Unit> {
    public async Task<Unit> Handle(DeleteTechnicianCommand request, CancellationToken cancellationToken) {
        var technician = await manager.Technicians.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new NotFoundException(nameof(TechnicianEntity), request.Id);

        await manager.Technicians.DeleteAsync(technician, cancellationToken);

        return Unit.Value;
    }
}