using System.Collections.Generic;
using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.GarageObject;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.GarageObject.GetGarageStatistics;
public class GetGarageStatisticsQueryHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    ) : IRequestHandler<GetGarageStatisticsQuery, List<GarageObjectStatisticsDto>>
{
    public async Task<List<GarageObjectStatisticsDto>> Handle(GetGarageStatisticsQuery query, CancellationToken cancellationToken)
    {
        var garages = await repositoryManager.GarageObjects.GetAllAsync(cancellationToken);

        var result = new List<GarageObjectStatisticsDto>();

        foreach (var garage in garages)
        {
            var stats = new GarageObjectStatisticsDto
            {
                Id = garage.Id,
                Name = garage.Name,
                TotalVehicles = garage.VehiclesStored?.Count ?? 0
            };

            if (garage.VehiclesStored != null)
            {
                foreach (var vehicle in garage.VehiclesStored)
                {
                    if (!stats.VehiclesByCategory.ContainsKey(vehicle.Type))
                        stats.VehiclesByCategory[vehicle.Type] = 0;

                    stats.VehiclesByCategory[vehicle.Type]++;
                }
            }

            result.Add(stats);
        }

        return result;
    }
}
