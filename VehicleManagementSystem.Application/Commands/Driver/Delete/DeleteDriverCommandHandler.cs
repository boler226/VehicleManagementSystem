using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Driver.Delete; 
public class DeleteDriverCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<DeleteDriverCommand, Unit> {
    public async Task<Unit> Handle(DeleteDriverCommand request, CancellationToken cancellationToken) {
        var driver = await manager.Drivers.GetByIdAsync(request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(DriverEntity), request.Id);

        await manager.DriverTransports.DeleteByDriverIdAsync(request.Id, cancellationToken);
        await manager.Drivers.DeleteAsync(driver, cancellationToken);

        return Unit.Value;
    }
}
