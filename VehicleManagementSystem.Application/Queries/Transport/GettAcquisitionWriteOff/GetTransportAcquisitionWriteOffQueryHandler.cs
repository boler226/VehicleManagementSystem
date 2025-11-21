using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Transport.GettAcquisitionWriteOff;
public class GetTransportAcquisitionWriteOffHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    )
    : IRequestHandler<GetTransportAcquisitionWriteOffQuery, IEnumerable<TransportAcquisitionWriteOffDto>>
{
    public async Task<IEnumerable<TransportAcquisitionWriteOffDto>> Handle(
       GetTransportAcquisitionWriteOffQuery request,
       CancellationToken cancellationToken)
    {
        var transports = await repositoryManager.Transports.GetTransportsByPeriodAsync(
            request.FromDate, request.ToDate, cancellationToken);

        return mapper.Map<IEnumerable<TransportAcquisitionWriteOffDto>>(transports);
    }
}