using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.Queries.Transport.GetWithRoutesByPeriod;

public record GetWithRoutesByPeriodQuery(Guid Id, DateTime From, DateTime To) : IRequest<TransportWithRoutesDto>;
