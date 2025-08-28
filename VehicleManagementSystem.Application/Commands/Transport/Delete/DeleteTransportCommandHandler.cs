using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Transport.DeleteTransport
{
    public class DeleteTransportCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteTransportCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {
            var transport = await unitOfWork.Transports.GetByIdAsync(request.Id, cancellationToken)
                            ?? throw new NotFoundException(nameof(TransportEntity), request.Id);

            await unitOfWork.DriverTransports.DeleteByTransportIdAsync(request.Id, cancellationToken);
            await unitOfWork.Transports.DeleteAsync(transport, cancellationToken);

            return Unit.Value;
        }
    }
}
