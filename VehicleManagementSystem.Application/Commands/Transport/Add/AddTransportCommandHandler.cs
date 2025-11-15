using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Transport.AddTransport;

public class AddTransportCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddTransportCommand, Guid>
{
    public async Task<Guid> Handle(AddTransportCommand request, CancellationToken cancellationToken) {
        var transport = new TransportEntity {
            Id = Guid.NewGuid(),
            LicensePlate = request.LicensePlate,
            Brand = request.Brand,
            Model = request.Model,
            Type = request.Type,
            Capacity = request.Capacity,
            LoadCapacity = request.LoadCapacity,
            IsWrittenOff = false,
        };

        if (request.GarageId is not null) {
            var garage = await manager.GarageObjects.GetByIdAsync(request.GarageId.Value, cancellationToken)
                         ?? throw new NotFoundException(nameof(GarageObjectEntity), request.GarageId);

            transport.GarageObject = garage;
            transport.GarageObjectId = garage.Id;
        }

        await manager.Transports.AddAsync(transport, cancellationToken);
        return transport.Id;
    }
}