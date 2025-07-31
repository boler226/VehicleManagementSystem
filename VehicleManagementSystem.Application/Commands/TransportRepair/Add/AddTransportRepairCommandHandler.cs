using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Add {
    public class AddTransportRepairCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddTransportRepairCommand, Guid> {
        public async Task<Guid> Handle(AddTransportRepairCommand request, CancellationToken cancellationToken) {
            var transport = await unitOfWork.Transports.GetByIdAsync(request.TransportId, cancellationToken)
                            ?? throw new Exception("Transport not found");

            var repair = new TransportRepairEntity {
                Id = Guid.NewGuid(),
                TransportId = request.TransportId,
                Transport = transport,
                RepairDate = DateTime.UtcNow,
                Cost = request.Cost
            };

            await unitOfWork.TransportRepairs.AddAsync(repair, cancellationToken);

            return repair.Id;
        }
    }
}
