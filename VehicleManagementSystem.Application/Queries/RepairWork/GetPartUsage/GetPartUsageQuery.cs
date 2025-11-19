using MediatR;
using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.Queries.RepairWork.GetPartUsage;
public record GetPartUsageQuery(TransportEnum Category) : IRequest<List<PartUsageDto>>;