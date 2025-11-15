using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Team;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Team.GetAll; 
public class GetAllTeamsQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllTeamsQuery, List<TeamDto>> {
    public async Task<List<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken) {
        var teams = await manager.Teams.GetAllAsync(cancellationToken);

        if (teams is not null) {
            foreach (var team in teams)
                team.Drivers = await manager.Drivers.GetAllByTeamIdAsync(team.Id, cancellationToken);
        }   

        return mapper.Map<List<TeamDto>>(teams);
    }
}
