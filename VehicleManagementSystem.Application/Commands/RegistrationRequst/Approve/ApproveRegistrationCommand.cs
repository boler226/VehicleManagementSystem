using MediatR;

namespace VehicleManagementSystem.Application.Commands.RegistrationRequst.Approve;
public record ApproveRegistrationCommand(Guid RequestId) : IRequest<Guid>;