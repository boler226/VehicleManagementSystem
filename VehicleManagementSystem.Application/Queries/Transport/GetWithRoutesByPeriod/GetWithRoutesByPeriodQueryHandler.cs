using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Transport.GetWithRoutesByPeriod;

public class GetWithRoutesByPeriodQueryHandler(
    IRepositoryManager manager,
    IMapper mapper) : IRequestHandler<GetWithRoutesByPeriodQuery, TransportWithRoutesDto>
{
    public async Task<TransportWithRoutesDto> Handle(GetWithRoutesByPeriodQuery request, CancellationToken cancellationToken)
    {
        var result = await manager.Transports.GetWithRoutesByPeriodAsync(request.Id, request.From, request.To, cancellationToken);

        return mapper.Map<TransportWithRoutesDto>(result);
    }
}
