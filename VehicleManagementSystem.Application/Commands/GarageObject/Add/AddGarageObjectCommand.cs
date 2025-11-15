using MediatR;

namespace VehicleManagementSystem.Application.Commands.GarageObject.Add; 
public record AddGarageObjectCommand(string Name, string Location) : IRequest<Guid>;
