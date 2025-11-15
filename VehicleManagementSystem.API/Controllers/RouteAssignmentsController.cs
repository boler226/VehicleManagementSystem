using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.RouteAssignment.Add;
using VehicleManagementSystem.Application.Commands.RouteAssignment.Delete;
using VehicleManagementSystem.Application.Commands.RouteAssignment.Update;
using VehicleManagementSystem.Application.Queries.RouteAssignment.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class RouteAssignmentsController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllRouteAssignmentsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddRouteAssignmentCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRouteAssignmentCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteRouteAssignmentCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
