using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.RepairWork.GetAll {
    public class GetAllRepairWorksQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllRepairWorksQuery, List<RepairWorkDto>> {
        public async Task<List<RepairWorkDto>> Handle(GetAllRepairWorksQuery request, CancellationToken cancellationToken) {
            var works = await unitOfWork.RepairWorks.GetAllAsync(cancellationToken)
                        ?? throw new Exception("Repair works does not exist");

            return mapper.Map<List<RepairWorkDto>>(works);
        }
    }
}
