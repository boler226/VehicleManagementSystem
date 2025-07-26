using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Driver.Update {
    public class UpdateDriverCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateDriverCommand, Unit> {
        public async Task<Unit> Handle(UpdateDriverCommand request, CancellationToken cancellationToken) {
            var driver = await unitOfWork.Drivers.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new Exception("Driver not found");

            if (!string.IsNullOrWhiteSpace(request.FullName))
                driver.FullName = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.LicenseNumber))
                driver.LicenseNumber = request.LicenseNumber;

            if (request.TeamId.HasValue) {
                var team = await unitOfWork.Teams.GetByIdAsync(request.TeamId.Value, cancellationToken)
                    ?? throw new Exception("Team not found");

                driver.TeamId = team.Id;
                driver.Team = team;
            }

            await unitOfWork.Drivers.UpdateAsync(driver, cancellationToken);
            
            return Unit.Value;
        }
    }
}
