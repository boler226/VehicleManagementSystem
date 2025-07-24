using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Driver.Delete {
    public class DeleteDriverCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteDriverCommand, Unit> {
        public async Task<Unit> Handle(DeleteDriverCommand request, CancellationToken cancellationToken) {
            var driver = await unitOfWork.Drivers.GetByIdAsync(request.Id, cancellationToken)
                         ?? throw new Exception("Driver not found");

            await unitOfWork.DriverTransports.DeleteByDriverIdAsync(request.Id, cancellationToken);
            await unitOfWork.Drivers.DeleteAsync(driver, cancellationToken);

            return Unit.Value;
        }
    }
}
