using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Application.Queries.Transport.GetWithRoutesByPeriod;

public class GetWithRoutesByPeriodQueryHandler(
    IRepositoryManager manager,
    IMapper mapper)
{
    public async Task<TransportWithRoutesDto> Handle(GetWithRoutesByPeriodQuery request, CancellationToken cancellationToken)
    {
        var result = await manager.Transports.GetWithRoutesByPeriodAsync(request.Id, request.From, request.To, cancellationToken);

        return mapper.Map<TransportWithRoutesDto>(result);
    }
}
