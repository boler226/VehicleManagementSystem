using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.TransportRepair.Add;
using VehicleManagementSystem.Application.Commands.TransportRepair.Delete;
using VehicleManagementSystem.Application.Commands.TransportRepair.Update;
using VehicleManagementSystem.Application.Queries.TransportRepair.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class TransportRepairsController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTransportRepairsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTransportRepairCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTransportRepairCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteTransportRepairCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
