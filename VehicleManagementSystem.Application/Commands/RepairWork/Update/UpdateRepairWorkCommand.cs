using MediatR;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Update; 
public record UpdateRepairWorkCommand(Guid Id, string? PartName, string? WorkDescription) : IRequest<Unit>;
