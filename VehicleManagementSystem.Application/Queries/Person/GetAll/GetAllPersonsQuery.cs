using MediatR;
using VehicleManagementSystem.Application.DTOs.Person;

namespace VehicleManagementSystem.Application.Queries.Person.GetAll {
    public record GetAllPersonsQuery : IRequest<List<PersonDto>>;
}
