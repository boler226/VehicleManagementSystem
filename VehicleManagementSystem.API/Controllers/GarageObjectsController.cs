using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.GarageObject.Add;
using VehicleManagementSystem.Application.Commands.GarageObject.Delete;
using VehicleManagementSystem.Application.Commands.GarageObject.Update;
using VehicleManagementSystem.Application.Queries.GarageObject.GetAll;
using VehicleManagementSystem.Application.Queries.GarageObject.GetGarageStatistics;

namespace VehicleManagementSystem.API.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class GarageObjectsController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Guest,Authorized,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllGarageObjectQuery());
        return Ok(result);
    }

    [HttpGet("statistics")]
    [Authorize(Roles = "Authorized,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetStatictics()
    {
        var result = await mediator.Send(new GetGarageStatisticsQuery());
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Add(AddGarageObjectCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Update(UpdateGarageObjectCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteGarageObjectCommand(id));
        return Ok(result);
    }
}