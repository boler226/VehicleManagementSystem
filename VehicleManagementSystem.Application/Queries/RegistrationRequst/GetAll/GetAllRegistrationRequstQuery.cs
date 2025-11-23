using MediatR;
using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.Application.Queries.RegistrationRequst.GetAll;
public record GetAllRegistrationRequestQuery() : IRequest<List<RegistrationRequest>>;
