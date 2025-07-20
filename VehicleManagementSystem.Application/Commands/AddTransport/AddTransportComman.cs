using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.Commands.AddTransport {
    public record AddTransportCommand(
        string LicensePlate,
        string Brand,
        string Model,
        TransportEnum Type,
        int? Capacity,
        double? LoadCapacity
    ) : IRequest<Guid>;
}
