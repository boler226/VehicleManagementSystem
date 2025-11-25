using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.RegistrationRequst.Approve;
using VehicleManagementSystem.Application.Commands.RegistrationRequst.Reject;
using VehicleManagementSystem.Application.Queries.RegistrationRequst.GetAll;

namespace VehicleManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "AdminSD")]
public class RegistrationRequestController(IMediator mediator) : Controller
{
    [HttpGet("registration-requests")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllRegistrationRequestQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost("{id}/approve-registration")]
    public async Task<IActionResult> Approve(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new ApproveRegistrationCommand(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost("{id}/reject-registration")]
    public async Task<IActionResult> Reject(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new RejectRegistrationCommand(id), cancellationToken);
        return Ok(result);
    }
}