using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Driver.GetByTransportModels;
public class GetDriversByTransportModelsQueryHandler(
    IRepositoryManager repositoryManager
    ) : IRequestHandler<GetDriversByTransportModelsQuery, DriversTransportReportDto>
{
    public async Task<DriversTransportReportDto> Handle(GetDriversByTransportModelsQuery request, CancellationToken cancellationToken)
    {
        var drivers = await repositoryManager.Drivers.GetAllAsync(cancellationToken);

        var driverDtos = new List<DriverItemDto>();

        foreach (var driver in drivers)
        {
            var transports = await repositoryManager.DriverTransports
                .GetByDriverIdAsync(driver.Id, cancellationToken);

            var models = transports
                .Where(dt => dt.Transport != null)
                .Select(dt => dt.Transport.Model)
                .Distinct()
                .ToList();

            driverDtos.Add(new DriverItemDto
            {
                Id = driver.Id,
                FullName = driver.FullName,
                TransportModels = models
            });
        }

        var report = new DriversTransportReportDto
        {
            TotalDrivers = driverDtos.Count,
            Drivers = driverDtos
        };

        if (request.Models is not null && request.Models.Any())
        {
            var stats = request.Models.ToDictionary(
                model => model,
                model => driverDtos.Count(d => d.TransportModels.Contains(model))
            );

            report.DriversByModel = stats;
        }

        return report;
    }
}