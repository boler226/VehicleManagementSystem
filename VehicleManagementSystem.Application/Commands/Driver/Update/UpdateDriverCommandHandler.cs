using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Driver.Update; 
public class UpdateDriverCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<UpdateDriverCommand, Unit> {
    public async Task<Unit> Handle(UpdateDriverCommand request, CancellationToken cancellationToken) {
        var driver = await manager.Drivers.GetByIdAsync(request.Id, cancellationToken)
                           ?? throw new NotFoundException(nameof(DriverEntity), request.Id);

        if (!string.IsNullOrWhiteSpace(request.FullName))
            driver.FullName = request.FullName;

        if (request.TeamId.HasValue) {
            var team = await manager.Teams.GetByIdAsync(request.TeamId.Value, cancellationToken)
                             ?? throw new NotFoundException(nameof(TeamEntity), request.TeamId);

            driver.TeamId = team.Id;
            driver.Team = team;
        }

        await manager.Drivers.UpdateAsync(driver, cancellationToken);
        
        return Unit.Value;
    }
}
