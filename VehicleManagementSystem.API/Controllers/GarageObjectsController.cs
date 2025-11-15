using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.GarageObject.Add;
using VehicleManagementSystem.Application.Commands.GarageObject.Delete;
using VehicleManagementSystem.Application.Commands.GarageObject.Update;
using VehicleManagementSystem.Application.Queries.GarageObject.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class GarageObjectsController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllGarageObjectQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddGarageObjectCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateGarageObjectCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteGarageObjectCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
