using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.MileageRecord;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.MileageRecord.GetAll; 
public class GetAllMileageRecordsQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllMileageRecordsQuery, List<MileageRecordDto>> {
    public async Task<List<MileageRecordDto>> Handle(GetAllMileageRecordsQuery request, CancellationToken cancellationToken) {
        var mileageRecords = await manager.MileageRecords.GetAllAsync(cancellationToken);

        return mapper.Map<List<MileageRecordDto>>(mileageRecords);
    }
}
