using MediatR;
using VehicleManagementSystem.Application.DTOs.RepairWork;

namespace VehicleManagementSystem.Application.Queries.RepairWork.GetAll {
    public record GetAllRepairWorksQuery : IRequest<List<RepairWorkDto>>;
}
