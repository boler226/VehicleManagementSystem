using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.Queries.Transport.GetCargoReport;
public record GetCargoTransportReportQuery(Guid Id, DateTime FromDate, DateTime ToDate)
    : IRequest<CargoTransportReportDto>;