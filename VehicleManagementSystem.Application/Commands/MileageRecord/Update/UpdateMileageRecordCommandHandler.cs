using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Update {
    public class UpdateMileageRecordCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateMileageRecordCommand, Unit> {
        public async Task<Unit> Handle(UpdateMileageRecordCommand request, CancellationToken cancellationToken) {
            var mileageRecord = await unitOfWork.MileageRecords.GetByIdAsync(request.Id, cancellationToken)
                                ?? throw new Exception("MileageRecord not found");

            if (request.TransportId.HasValue) {
                var transport = await unitOfWork.Transports.GetByIdAsync(request.TransportId.Value, cancellationToken)
                                ?? throw new Exception("Transport not found");

                mileageRecord.Transport = transport;
                mileageRecord.TransportId = transport.Id;
            }

            if (request.Date.HasValue)
                mileageRecord.Date = request.Date.Value;

            if (request.Kilometers.HasValue)
                mileageRecord.Kilometers = request.Kilometers.Value;

            await unitOfWork.MileageRecords.UpdateAsync(mileageRecord, cancellationToken);

            return Unit.Value;
        }
    }
}
