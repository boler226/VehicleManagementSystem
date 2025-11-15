using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Transport.AddTransport;
using VehicleManagementSystem.Application.Commands.Transport.DeleteTransport;
using VehicleManagementSystem.Application.Commands.Transport.Update;
using VehicleManagementSystem.Application.Queries.Transport.GetAll;

namespace VehicleManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransportsController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTransportsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteTransportCommand(id));
        return Ok(result);
    }
} 
