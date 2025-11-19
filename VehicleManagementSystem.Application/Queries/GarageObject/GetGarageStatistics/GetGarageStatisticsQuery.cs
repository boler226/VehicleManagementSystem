using MediatR;
using VehicleManagementSystem.Application.DTOs.GarageObject;

namespace VehicleManagementSystem.Application.Queries.GarageObject.GetGarageStatistics;
public record GetGarageStatisticsQuery() : IRequest<List<GarageObjectStatisticsDto>>;
