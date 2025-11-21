using MediatR;
using VehicleManagementSystem.Application.DTOs.Driver;

namespace VehicleManagementSystem.Application.Queries.Driver.GetByTransportModels;
public record GetDriversByTransportModelsQuery(IEnumerable<string>? Models)
    : IRequest<DriversTransportReportDto>;