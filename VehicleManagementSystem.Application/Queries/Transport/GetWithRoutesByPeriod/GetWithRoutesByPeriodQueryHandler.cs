using AutoMapper;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Application.Queries.Transport.GetWithRoutesByPeriod
{
    public class GetWithRoutesByPeriodQueryHandler(
        ITransportRepository repository,
        IMapper mapper)
    {
        public async Task<TransportWithRoutesDto> Handle(GetWithRoutesByPeriodQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetWithRoutesByPeriodAsync(request.Id, request.From, request.To, cancellationToken)
                ?? throw new Exception("Transport not found");

            return mapper.Map<TransportWithRoutesDto>(result);
        }
    }
}
