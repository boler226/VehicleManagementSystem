using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Transport.AddTransport
{
    public class AddTransportCommandHandler(
        ITransportRepository repository
        ) : IRequestHandler<AddTransportCommand, Guid>
    {
        public async Task<Guid> Handle(AddTransportCommand request, CancellationToken cancellationToken)
        {
            var entity = new TransportEntity {
                Id = Guid.NewGuid(),
                LicensePlate = request.LicensePlate,
                Brand = request.Brand,
                Model = request.Model,
                Type = request.Type,
                Capacity = request.Capacity,
                LoadCapacity = request.LoadCapacity,
                IsWrittenOff = false
            };

            await repository.AddAsync(entity, cancellationToken);
            return entity.Id;
        }
    }
}
