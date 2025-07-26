using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Team;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Team.GetAll {
    public class GetAllTeamsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllTeamsQuery, List<TeamDto>> {
        public async Task<List<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken) {
            var teams = await unitOfWork.Teams.GetAllAsync(cancellationToken)
                        ?? throw new Exception("Teams does not exist");

            foreach (var team in teams) {
                team.Drivers = await unitOfWork.Drivers.GetAllByTeamIdAsync(team.Id, cancellationToken);
            }

            return mapper.Map<List<TeamDto>>(teams);
        }
    }
}
