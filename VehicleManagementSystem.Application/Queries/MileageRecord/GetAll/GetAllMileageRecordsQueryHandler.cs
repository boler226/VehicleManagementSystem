using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.MileageRecord;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.MileageRecord.GetAll {
    public class GetAllMileageRecordsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllMileageRecordsQuery, List<MileageRecordDto>> {
        public async Task<List<MileageRecordDto>> Handle(GetAllMileageRecordsQuery request, CancellationToken cancellationToken) {
            var mileageRecords = await unitOfWork.MileageRecords.GetAllAsync(cancellationToken);

            return mapper.Map<List<MileageRecordDto>>(mileageRecords);
        }
    }
}
