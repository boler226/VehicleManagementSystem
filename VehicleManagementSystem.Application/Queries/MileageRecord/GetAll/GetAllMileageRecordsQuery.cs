using MediatR;
using VehicleManagementSystem.Application.DTOs.MileageRecord;

namespace VehicleManagementSystem.Application.Queries.MileageRecord.GetAll; 
public record GetAllMileageRecordsQuery() : IRequest<List<MileageRecordDto>>;
