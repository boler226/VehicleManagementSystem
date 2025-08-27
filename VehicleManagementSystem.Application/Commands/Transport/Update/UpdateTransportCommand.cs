using MediatR;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.Commands.Transport.Update {
    public record UpdateTransportCommand(Guid Id, Guid? GarageId, string? LicensePlate, TransportEnum? Type, int? Capacity, double? LoadCapacity) : IRequest<Unit>;
}
