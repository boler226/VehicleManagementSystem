using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.DriverTransport.Add;
using VehicleManagementSystem.Application.Commands.DriverTransport.Delete;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]")]
public class DriverTransportsController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Add(AddDriverTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteDriverTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
