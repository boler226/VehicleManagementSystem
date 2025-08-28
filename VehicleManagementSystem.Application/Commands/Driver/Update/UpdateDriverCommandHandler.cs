using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Driver.Update {
    public class UpdateDriverCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateDriverCommand, Unit> {
        public async Task<Unit> Handle(UpdateDriverCommand request, CancellationToken cancellationToken) {
            var driver = await unitOfWork.Drivers.GetByIdAsync(request.Id, cancellationToken)
                               ?? throw new NotFoundException(nameof(DriverEntity), request.Id);

            if (!string.IsNullOrWhiteSpace(request.FullName))
                driver.FullName = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.LicenseNumber))
                driver.LicenseNumber = request.LicenseNumber;

            if (request.TeamId.HasValue) {
                var team = await unitOfWork.Teams.GetByIdAsync(request.TeamId.Value, cancellationToken)
                                 ?? throw new NotFoundException(nameof(TeamEntity), request.TeamId);

                driver.TeamId = team.Id;
                driver.Team = team;
            }

            await unitOfWork.Drivers.UpdateAsync(driver, cancellationToken);
            
            return Unit.Value;
        }
    }
}
