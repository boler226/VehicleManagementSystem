using MediatR;

namespace VehicleManagementSystem.Application.Commands.Driver.Add; 
public record AddDriverCommand(string FullName, Guid TeamId) : IRequest<Guid>;
