using MediatR;
using VehicleManagementSystem.Application.DTOs.GarageObject;

namespace VehicleManagementSystem.Application.Queries.GarageObject.GetAll {
    public record GetAllGarageObjectQuery : IRequest<List<GarageObjectDto>>;
}
