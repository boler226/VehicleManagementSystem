using MediatR;

namespace VehicleManagementSystem.Application.Commands.Team.Update; 
public record UpdateTeamCommand(
    Guid Id,
    string Name,
    Guid? ForemanId,
    Guid? MasterId,
    Guid? SectionHeadId,
    Guid? WorkshopHeadId
) : IRequest<Unit>;
