using MediatR;
using VehicleManagementSystem.Application.DTOs.TransportRepair;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.Queries.TransportRepair.GetStats;
public record GetTransportRepairStatsQuery(
    TransportEnum? Category,
    string? Brand,
    Guid? TransportId,
    DateTime? FromDate,
    DateTime? ToDate
) : IRequest<IEnumerable<TransportRepairStatsDto>>;