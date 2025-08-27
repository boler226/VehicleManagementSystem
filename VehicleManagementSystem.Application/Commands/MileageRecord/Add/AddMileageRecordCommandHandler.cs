using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Add {
    public class AddMileageRecordCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddMileageRecordCommand, Guid> {
        public async Task<Guid> Handle(AddMileageRecordCommand reqeust, CancellationToken cancellationToken) {
            var transport = await unitOfWork.Transports.GetByIdAsync(reqeust.TransportId, cancellationToken)
                            ?? throw new Exception("Transport not found");

            var mileageRecord = new MileageRecordEntity {
                Id = Guid.NewGuid(),
                Transport = transport,
                TransportId = transport.Id,
                Date = reqeust.Date,
                Kilometers = reqeust.Kilometers
            };

            await unitOfWork.MileageRecords.AddAsync(mileageRecord, cancellationToken);

            return mileageRecord.Id;
        }
    }
}
