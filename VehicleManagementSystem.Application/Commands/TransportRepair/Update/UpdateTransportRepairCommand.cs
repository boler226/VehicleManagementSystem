using MediatR;

namespace VehicleManagementSystem.Application.Commands.TransportRepair.Update; 
public record UpdateTransportRepairCommand(Guid Id, Guid? GarageId, DateTime? RepairDate, double? Cost) : IRequest<Unit>;
