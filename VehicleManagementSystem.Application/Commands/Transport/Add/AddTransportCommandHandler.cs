using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Enums;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Transport.AddTransport;

public class AddTransportCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddTransportCommand, Guid>
{
    public async Task<Guid> Handle(AddTransportCommand request, CancellationToken cancellationToken) {
        if (!Enum.TryParse<TransportEnum>(request.Type, ignoreCase: true, out var parsedType))
            throw new Exception($"Invalid transport type: {request.Type}");

        var transport = new TransportEntity {
            Id = Guid.NewGuid(),
            LicensePlate = request.LicensePlate,
            Brand = request.Brand,
            Model = request.Model,
            Type = parsedType,
            Capacity = request.Capacity,
            LoadCapacity = request.LoadCapacity,
            IsWrittenOff = true
        };

        if (request.GarageId is not null) {
            var garage = await manager.GarageObjects.GetByIdAsync(request.GarageId.Value, cancellationToken)
                         ?? throw new NotFoundException(nameof(GarageObjectEntity), request.GarageId);

            transport.GarageObjectId = garage.Id;

            garage.VehiclesStored?.Add(transport);

            await manager.GarageObjects.UpdateAsync(garage, cancellationToken);
        }

        await manager.Transports.AddAsync(transport, cancellationToken);

        return transport.Id;
    }
}