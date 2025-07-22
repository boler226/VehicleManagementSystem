using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Transport.DeleteTransport
{
    public class DeleteTransportCommandHandler(
        ITransportRepository repository
        ) : IRequestHandler<DeleteTransportCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {
            var transport = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (transport is null)
                throw new Exception("Transport not found");

            await repository.DeleteAsync(transport, cancellationToken);
            return Unit.Value;
        }
    }
}
