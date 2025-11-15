using MediatR;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.Commands.Transport.AddTransport;

public record AddTransportCommand(
    Guid? GarageId,
    string LicensePlate,
    string Brand,
    string Model,
    TransportEnum Type,
    int? Capacity,
    double? LoadCapacity
) : IRequest<Guid>;
