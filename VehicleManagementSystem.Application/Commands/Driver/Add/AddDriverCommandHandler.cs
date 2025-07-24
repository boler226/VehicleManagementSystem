using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Driver.Add {
    public class AddDriverCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddDriverCommand, Guid> {
        public async Task<Guid> Handle(AddDriverCommand request, CancellationToken cancellationToken) {
            var team = await unitOfWork.Teams.GetByIdAsync(request.TeamId, cancellationToken)
                ?? throw new Exception("Team not found");

            var entity = new DriverEntity {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                LicenseNumber = request.LicenseNumber,
                TeamId = team.Id,
                Team = team
            };

            await unitOfWork.Drivers.AddAsync(entity, cancellationToken);
            return entity.Id;
        }
    }
}
