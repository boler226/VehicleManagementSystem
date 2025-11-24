using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Team.Add;
using VehicleManagementSystem.Application.Commands.Team.Delete;
using VehicleManagementSystem.Application.Commands.Team.Update;
using VehicleManagementSystem.Application.Queries.Team.GetAll;
using VehicleManagementSystem.Application.Queries.Team.GetSubordinates;

namespace VehicleManagementSystem.API.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class TeamsController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Guest,Authorized,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTeamsQuery());
        return Ok(result);
    }

    [HttpGet("{leaderId}/subordinates")]
    [Authorize(Roles = "Authorized,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetSubordinates(Guid leaderId)
    {
        var result = await mediator.Send(new GetSubordinatesQuery(leaderId));
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Add(AddTeamCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Update(UpdateTeamCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteTeamCommand(id));
        return Ok(result);
    }
}