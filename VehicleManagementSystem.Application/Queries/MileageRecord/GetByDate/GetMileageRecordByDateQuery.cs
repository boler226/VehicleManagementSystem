using MediatR;
using VehicleManagementSystem.Application.DTOs.MileageRecord;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.Queries.MileageRecord.GetByDate;
public record GetMileageRecordByDateQuery(
      DateTime Date,
      TransportEnum? Category,
      Guid? TransportId
  ) : IRequest<List<MileageRecordDto>>;