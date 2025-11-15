using MediatR;

namespace VehicleManagementSystem.Application.Commands.RepairWork.Delete; 
public record DeleteRepairWorkCommand(Guid Id) : IRequest<Unit>;
