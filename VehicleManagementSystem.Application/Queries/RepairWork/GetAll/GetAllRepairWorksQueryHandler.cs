using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.RepairWork.GetAll; 
public class GetAllRepairWorksQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllRepairWorksQuery, List<RepairWorkDto>> {
    public async Task<List<RepairWorkDto>> Handle(GetAllRepairWorksQuery request, CancellationToken cancellationToken) {
        var works = await manager.RepairWorks.GetAllAsync(cancellationToken);

        return mapper.Map<List<RepairWorkDto>>(works);
    }
}
