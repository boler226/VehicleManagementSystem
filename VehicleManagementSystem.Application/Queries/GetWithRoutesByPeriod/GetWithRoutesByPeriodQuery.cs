using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.Queries.GetWithRoutesByPeriod
{
    public record GetWithRoutesByPeriodQuery(Guid Id, DateTime From, DateTime To) : IRequest<TransportWithRoutesDto>; 
}
