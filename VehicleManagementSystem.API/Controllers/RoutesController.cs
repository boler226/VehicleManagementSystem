using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Route.Add;
using VehicleManagementSystem.Application.Commands.Route.Delete;
using VehicleManagementSystem.Application.Commands.Route.Update;
using VehicleManagementSystem.Application.Queries.Route.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class RoutesController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllRoutesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddRouteCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRouteCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteRouteCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
