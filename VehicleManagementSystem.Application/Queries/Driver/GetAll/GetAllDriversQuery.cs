using MediatR;
using VehicleManagementSystem.Application.DTOs.Driver;

namespace VehicleManagementSystem.Application.Queries.Driver.GetAll;
public record GetAllDriversQuery : IRequest<List<DriverDto>>;
