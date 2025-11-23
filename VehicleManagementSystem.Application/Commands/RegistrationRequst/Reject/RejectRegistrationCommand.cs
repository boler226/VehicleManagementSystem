using MediatR;

namespace VehicleManagementSystem.Application.Commands.RegistrationRequst.Reject;
public record RejectRegistrationCommand(Guid RequestId) : IRequest<Unit>;
