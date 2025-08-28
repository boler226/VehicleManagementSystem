using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Add {
    public class AddMileageRecordCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddMileageRecordCommand, Guid> {
        public async Task<Guid> Handle(AddMileageRecordCommand request, CancellationToken cancellationToken) {
            var transport = await unitOfWork.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                            ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

            var mileageRecord = new MileageRecordEntity {
                Id = Guid.NewGuid(),
                Transport = transport,
                TransportId = transport.Id,
                Date = request.Date,
                Kilometers = request.Kilometers
            };

            await unitOfWork.MileageRecords.AddAsync(mileageRecord, cancellationToken);

            return mileageRecord.Id;
        }
    }
}
