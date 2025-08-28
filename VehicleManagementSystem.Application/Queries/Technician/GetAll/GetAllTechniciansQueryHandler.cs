using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Technician.GetAll
{
    public class GetAllTechniciansQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllTechniciansQuery, List<TechnicianDto>>
    {
        public async Task<List<TechnicianDto>> Handle(GetAllTechniciansQuery request, CancellationToken cancellationToken)
        {
            var technicians = await unitOfWork.Technicians.GetAllAsync(cancellationToken);

            if (technicians is not null) {
                foreach (var technician in technicians)
                    technician.RepairWorks = await unitOfWork.RepairWorks.GetAllByTechnicianIdAsync(technician.Id, cancellationToken);
            }        

            return mapper.Map<List<TechnicianDto>>(technicians);
        }
    }
}
