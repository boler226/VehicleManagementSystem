using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Delete {
    public class DeleteMileageRecordCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteMileageRecordCommand, Unit> {
        public async Task<Unit> Handle(DeleteMileageRecordCommand request, CancellationToken cancellationToken) {
            var mileageRecord = await unitOfWork.MileageRecords.GetByIdAsync(request.Id, cancellationToken)
                                ?? throw new NotFoundException(nameof(MileageRecordEntity), request.Id);

            await unitOfWork.MileageRecords.DeleteAsync(mileageRecord, cancellationToken);

            return Unit.Value;
        } 
    }
}
