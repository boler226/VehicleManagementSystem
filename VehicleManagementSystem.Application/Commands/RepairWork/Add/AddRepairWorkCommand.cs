using MediatR;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Add; 
public record AddRepairWorkCommand(Guid TechnicianId, Guid RepairId, string PartName, string WorkDescription) : IRequest<Guid>;
