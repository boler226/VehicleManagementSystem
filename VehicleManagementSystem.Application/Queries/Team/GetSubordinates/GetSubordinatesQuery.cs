using MediatR;
using VehicleManagementSystem.Application.DTOs.Team;

namespace VehicleManagementSystem.Application.Queries.Team.GetSubordinates;
public record GetSubordinatesQuery(Guid LeaderId) : IRequest<SubordinatesReportDto>;