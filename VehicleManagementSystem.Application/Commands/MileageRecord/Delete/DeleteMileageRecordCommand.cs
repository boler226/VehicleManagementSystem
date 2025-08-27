using MediatR;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Delete {
    public record DeleteMileageRecordCommand(Guid Id) : IRequest<Unit>;
}
