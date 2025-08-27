using MediatR;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Update {
    public record UpdateMileageRecordCommand(Guid Id, Guid? TransportId, DateTime? Date, double? Kilometers) : IRequest<Unit>;
}