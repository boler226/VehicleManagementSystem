using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.TransportRepair;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.TransportRepair.GetStats;
public class GetTransportRepairStatsHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    ) : IRequestHandler<GetTransportRepairStatsQuery, IEnumerable<TransportRepairStatsDto>>
{
    public async Task<IEnumerable<TransportRepairStatsDto>> Handle(
       GetTransportRepairStatsQuery request,
       CancellationToken cancellationToken)
    {
        var transports = await repositoryManager.Transports.GetTransportsWithRepairsAsync(
            request.Category, request.Brand, request.TransportId, request.FromDate, request.ToDate, cancellationToken);

        return mapper.Map<IEnumerable<TransportRepairStatsDto>>(transports);
    }
}
