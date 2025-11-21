using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Driver.Add; 
public class AddDriverCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddDriverCommand, Guid> {
    public async Task<Guid> Handle(AddDriverCommand request, CancellationToken cancellationToken) {
        var team = await manager.Teams.GetByIdAsync(request.TeamId, cancellationToken)
                         ?? throw new NotFoundException(nameof(TeamEntity), request.TeamId);

        var driver = new DriverEntity {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            TeamId = team.Id,
            Team = team
        };

        await manager.Drivers.AddAsync(driver, cancellationToken);

        return driver.Id;
    }
}