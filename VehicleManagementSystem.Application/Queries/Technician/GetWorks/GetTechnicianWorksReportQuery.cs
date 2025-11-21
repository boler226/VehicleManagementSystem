using MediatR;
using VehicleManagementSystem.Application.DTOs.Technician;

namespace VehicleManagementSystem.Application.Queries.Technician.GetWorks;
public record GetTechnicianWorksReportQuery(
    Guid TechnicianId,
    DateTime FromDate,
    DateTime ToDate,
    Guid? TransportId
) : IRequest<TechnicianWorksReportDto>;