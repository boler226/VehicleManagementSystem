using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Update; 
public class UpdateMileageRecordCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<UpdateMileageRecordCommand, Unit> {
    public async Task<Unit> Handle(UpdateMileageRecordCommand request, CancellationToken cancellationToken) {
        var mileageRecord = await manager.MileageRecords.GetByIdAsync(request.Id, cancellationToken)
                            ?? throw new NotFoundException(nameof(MileageRecordEntity), request.Id);

        if (request.TransportId.HasValue) {
            var transport = await manager.Transports.GetByIdAsync(request.TransportId.Value, cancellationToken)
                            ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

            mileageRecord.Transport = transport;
            mileageRecord.TransportId = transport.Id;
        }

        if (request.Date.HasValue)
            mileageRecord.Date = request.Date.Value;

        if (request.Kilometers.HasValue)
            mileageRecord.Kilometers = request.Kilometers.Value;

        await manager.MileageRecords.UpdateAsync(mileageRecord, cancellationToken);

        return Unit.Value;
    }
}
