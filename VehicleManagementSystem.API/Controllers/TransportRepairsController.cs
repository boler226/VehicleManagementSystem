using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.TransportRepair.Add;
using VehicleManagementSystem.Application.Commands.TransportRepair.Delete;
using VehicleManagementSystem.Application.Commands.TransportRepair.Update;
using VehicleManagementSystem.Application.Queries.RepairWork.GetPartUsage;
using VehicleManagementSystem.Application.Queries.TransportRepair.GetAll;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]")]
public class TransportRepairsController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTransportRepairsQuery());
        return Ok(result);
    }

    [HttpGet("part-usage")]
    public async Task<IActionResult> GetPartUsage(
        [FromQuery] TransportEnum category)
    {
        var result = await mediator.Send(new GetPartUsageQuery(category));
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
