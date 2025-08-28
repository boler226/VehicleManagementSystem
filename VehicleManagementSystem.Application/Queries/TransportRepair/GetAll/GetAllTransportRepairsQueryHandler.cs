using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.TransportRepair;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.TransportRepair.GetAll {
    public class GetAllTransportRepairsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllTransportRepairsQuery, List<TransportRepairDto>> {
        public async Task<List<TransportRepairDto>> Handle(GetAllTransportRepairsQuery request, CancellationToken cancellationToken) {
            var repairs = await unitOfWork.TransportRepairs.GetAllAsync(cancellationToken);

            if (repairs is not null) {
                foreach (var repair in repairs) {
                    var works = await unitOfWork.RepairWorks.GetAllByRepairIdAsync(repair.Id, cancellationToken);

                    if (works is not null)
                        repair.RepairWorks = works;
                }
            }

            return mapper.Map<List<TransportRepairDto>>(repairs);
        }
    }
}
