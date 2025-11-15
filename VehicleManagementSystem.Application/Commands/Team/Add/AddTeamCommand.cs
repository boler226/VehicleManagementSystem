using MediatR;
using System;
using System.Collections.Generic;
namespace VehicleManagementSystem.Application.Commands.Team.Add; 
public record AddTeamCommand(
    string Name,
    Guid? ForemanId,
    Guid? MasterId,
    Guid? SectionHeadId,
    Guid? WorkshopHeadId
) : IRequest<Guid>;
