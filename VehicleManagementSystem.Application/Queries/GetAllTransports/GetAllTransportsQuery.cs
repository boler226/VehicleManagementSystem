using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.Queries.GetAllTransports {
    public record GetAllTransportsQuery() : IRequest<List<TransportDto>>;
}
