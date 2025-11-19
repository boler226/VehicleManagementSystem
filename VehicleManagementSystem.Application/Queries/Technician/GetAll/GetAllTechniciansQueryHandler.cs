using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Technician.GetAll;

public class GetAllTechniciansQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllTechniciansQuery, List<TechnicianDto>>
{
    public async Task<List<TechnicianDto>> Handle(GetAllTechniciansQuery request, CancellationToken cancellationToken)
    {
        var technicians = await manager.Technicians.GetAllAsync(cancellationToken);

        if (technicians is not null) {
            foreach (var technician in technicians)
                technician.RepairWorks = await manager.RepairWorks.GetByTechnicianIdAsync(technician.Id, cancellationToken);
        }        

        return mapper.Map<List<TechnicianDto>>(technicians);
    }
}
