using MediatR;

namespace VehicleManagementSystem.Application.Commands.Transport.AddTransport;

public record AddTransportCommand(
    Guid? GarageId,
    string LicensePlate,
    string Brand,
    string Model,
    string Type,
    int? Capacity,
    double? LoadCapacity
) : IRequest<Guid>;
