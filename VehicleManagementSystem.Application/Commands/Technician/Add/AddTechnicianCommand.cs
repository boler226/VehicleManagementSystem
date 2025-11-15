using MediatR;

namespace VehicleManagementSystem.Application.Commands.Technician.Add; 
public record AddTechnicianCommand(string FullName, string Specialty, Guid TeamId) : IRequest<Guid>;