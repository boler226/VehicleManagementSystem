using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.DriverTransport.Add;
using VehicleManagementSystem.Application.Commands.DriverTransport.Delete;

namespace VehicleManagementSystem.API.Controllers; 

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "OperatorSD,AdminSD")]
public class DriverTransportsController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Add(AddDriverTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{driverId}/{transportId}")]
    public async Task<IActionResult> Delete(Guid driverId, Guid transportId)
    {
        var result = await mediator.Send(new DeleteDriverTransportCommand(driverId, transportId));
        return Ok(result);
    }
}
