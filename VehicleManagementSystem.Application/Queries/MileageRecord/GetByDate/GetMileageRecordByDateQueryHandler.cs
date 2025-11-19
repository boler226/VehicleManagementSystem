using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.MileageRecord;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.MileageRecord.GetByDate;
public class GetMileageRecordByDateQueryHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    ) : IRequestHandler<GetMileageRecordByDateQuery, List<MileageRecordDto>>
{
    public async Task<List<MileageRecordDto>> Handle(GetMileageRecordByDateQuery request, CancellationToken cancellationToken)
    {
        var records = await repositoryManager.MileageRecords.GetByDateAsync(request.Date, cancellationToken);

        if (request.TransportId is not null)
        {
            records = records.Where(r => r.TransportId == request.TransportId).ToList();
        }

        if (request.Category is not null) 
        {
            records = records.Where(r => r.Transport.Type == request.Category).ToList();
        }

        return mapper.Map<List<MileageRecordDto>>(records);
    }
}