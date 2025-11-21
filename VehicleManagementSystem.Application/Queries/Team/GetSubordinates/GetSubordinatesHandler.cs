using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpCompress.Readers;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.Team;
using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Queries.Team.GetSubordinates;
public class GetSubordinatesHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    ) : IRequestHandler<GetSubordinatesQuery, SubordinatesReportDto>
{
    public async Task<SubordinatesReportDto> Handle(GetSubordinatesQuery request, CancellationToken cancellationToken)
    {

        var team = await repositoryManager.Teams.GetByLeaderIdAsync(request.LeaderId, cancellationToken)
            ?? throw new NotFoundException(nameof(TeamEntity), request.LeaderId);

        PersonEntity? leader = null;
        if (team.ForemanId == request.LeaderId) leader = team.Foreman;
        else if (team.MasterId == request.LeaderId) leader = team.Master;
        else if (team.SectionHeadId == request.LeaderId) leader = team.SectionHead;
        else if (team.WorkshopHeadId == request.LeaderId) leader = team.WorkshopHead;

        if (leader is null)
            throw new NotFoundException(nameof(PersonEntity), request.LeaderId);

        var drivers = await repositoryManager.Drivers.GetByTeamIdAsync(team.Id, cancellationToken);
        var technicians = await repositoryManager.Technicians.GetByTeamIdAsync(team.Id, cancellationToken);

        var dto = mapper.Map<SubordinatesReportDto>(team);

        dto.LeaderId = leader.Id;
        dto.LeaderName = leader.FullName;
        dto.LeaderPosition = leader.Position;

        dto.Drivers = drivers.Select(d => mapper.Map<DriverShortDto>(d));
        dto.Technicians = technicians.Select(t => mapper.Map<TechnicianShortDto>(t));

        return dto;
    }
}