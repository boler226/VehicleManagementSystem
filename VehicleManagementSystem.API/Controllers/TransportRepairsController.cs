using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.TransportRepair.Add;
using VehicleManagementSystem.Application.Commands.TransportRepair.Delete;
using VehicleManagementSystem.Application.Commands.TransportRepair.Update;
using VehicleManagementSystem.Application.Queries.RepairWork.GetPartUsage;
using VehicleManagementSystem.Application.Queries.TransportRepair.GetAll;

namespace VehicleManagementSystem.API.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class TransportRepairsController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Guest,Authorised,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTransportRepairsQuery());
        return Ok(result);
    }

    [HttpGet("part-usage")]
    [Authorize(Roles = "Authorised,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetPartUsage([FromQuery] GetPartUsageQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Add(AddTransportRepairCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Update(UpdateTransportRepairCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Delete(DeleteTransportRepairCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}