using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Technician.Add; 
public class AddTechnicianCommandHandler(
    IRepositoryManager manager
    ) : IRequestHandler<AddTechnicianCommand, Guid> {
    public async Task<Guid> Handle(AddTechnicianCommand request, CancellationToken cancellationToken) {
        var team = await manager.Teams.GetByIdAsync(request.TeamId, cancellationToken)
                   ?? throw new NotFoundException(nameof(TeamEntity), request.TeamId);

        var technician = new TechnicianEntity {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Specialty = request.Specialty,
            Team = team,
            TeamId = team.Id
        };

        await manager.Technicians.AddAsync(technician, cancellationToken);

        return technician.Id;
    }
}