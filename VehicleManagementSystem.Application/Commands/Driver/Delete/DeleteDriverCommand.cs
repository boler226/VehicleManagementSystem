using MediatR;

namespace VehicleManagementSystem.Application.Commands.Driver.Delete; 
public record DeleteDriverCommand(Guid Id) : IRequest<Unit>;
