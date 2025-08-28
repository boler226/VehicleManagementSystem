using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Driver.Delete {
    public class DeleteDriverCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteDriverCommand, Unit> {
        public async Task<Unit> Handle(DeleteDriverCommand request, CancellationToken cancellationToken) {
            var driver = await unitOfWork.Drivers.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new NotFoundException(nameof(DriverEntity), request.Id);

            await unitOfWork.DriverTransports.DeleteByDriverIdAsync(request.Id, cancellationToken);
            await unitOfWork.Drivers.DeleteAsync(driver, cancellationToken);

            return Unit.Value;
        }
    }
}
