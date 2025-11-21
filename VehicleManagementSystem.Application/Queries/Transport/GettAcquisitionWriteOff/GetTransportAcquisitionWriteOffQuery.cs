using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.Queries.Transport.GettAcquisitionWriteOff;
public record GetTransportAcquisitionWriteOffQuery(DateTime? FromDate, DateTime? ToDate)
    : IRequest<IEnumerable<TransportAcquisitionWriteOffDto>>;