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

    [HttpPost("approve-registration")]
    public async Task<IActionResult> Approve([FromBody] ApproveRegistrationCommand command, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPost("reject-registration")]
    public async Task<IActionResult> Reject([FromBody] RejectRegistrationCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}