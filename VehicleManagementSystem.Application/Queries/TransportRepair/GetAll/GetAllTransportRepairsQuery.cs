using MediatR;
using VehicleManagementSystem.Application.DTOs.TransportRepair;

namespace VehicleManagementSystem.Application.Queries.TransportRepair.GetAll {
    public record GetAllTransportRepairsQuery : IRequest<List<TransportRepairDto>>;
}
