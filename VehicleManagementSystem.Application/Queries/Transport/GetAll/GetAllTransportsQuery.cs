using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.Queries.Transport.GetAll;

public record GetAllTransportsQuery : IRequest<List<TransportDto>>;
