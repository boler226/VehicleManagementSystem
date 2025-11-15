using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Team.Add;
using VehicleManagementSystem.Application.Commands.Team.Delete;
using VehicleManagementSystem.Application.Commands.Team.Update;
using VehicleManagementSystem.Application.Queries.Team.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class TeamsController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTeamsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTeamCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTeamCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteTeamCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
