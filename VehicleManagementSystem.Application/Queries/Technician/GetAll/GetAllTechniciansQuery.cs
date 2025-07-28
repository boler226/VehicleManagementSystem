using MediatR;
using VehicleManagementSystem.Application.DTOs.Technician;

namespace VehicleManagementSystem.Application.Queries.Technician.GetAll
{
    public record GetAllTechniciansQuery : IRequest<List<TechnicianDto>>;
}
