using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Add; 
public class AddMileageRecordCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddMileageRecordCommand, Guid> {
    public async Task<Guid> Handle(AddMileageRecordCommand request, CancellationToken cancellationToken) {
        var transport = await manager.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                        ?? throw new NotFoundException(nameof(TransportEntity), request.TransportId);

        var mileageRecord = new MileageRecordEntity {
            Id = Guid.NewGuid(),
            Transport = transport,
            TransportId = transport.Id,
            Date = request.Date,
            Kilometers = request.Kilometers
        };

        await manager.MileageRecords.AddAsync(mileageRecord, cancellationToken);

        return mileageRecord.Id;
    }
}
