using MediatR;
using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.RepairWork.GetPartUsage;
public class GetPartUsageQueryHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<GetPartUsageQuery, List<PartUsageDto>>
{
    public async Task<List<PartUsageDto>> Handle(GetPartUsageQuery request, CancellationToken cancellationToken)
    {
        var transports = await repositoryManager.Transports.GetByTypeAsync(request.Category, cancellationToken);

        if (transports == null || transports.Count == 0)
            return [];

        var transportIds = transports.Select(t => t.Id).ToList();

        var repairs = await repositoryManager.TransportRepairs.GetByTransportIdsAsync(
            transportIds,
            cancellationToken
        );

        if (repairs == null || repairs.Count == 0)
            return [];

        var allWorks = repairs.SelectMany(r => r.RepairWorks).ToList();

        if (allWorks.Count == 0)
            return [];

        var result = allWorks
           .GroupBy(w => w.PartName)
           .Select(g => new PartUsageDto
           {
               PartName = g.Key,
               Count = g.Count()
           })
           .ToList();

        return result;
    }
}
