using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Driver.Add;
using VehicleManagementSystem.Application.Commands.Driver.Delete;
using VehicleManagementSystem.Application.Commands.Driver.Update;
using VehicleManagementSystem.Application.Queries.Driver.GetAll;
using VehicleManagementSystem.Application.Queries.Driver.GetByTransportModels;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]")]
public class DriversController(IMediator mediator) : Controller {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllDriversQuery());
        return Ok(result);
    }

    [HttpGet("driver-models")]
    public async Task<IActionResult> GetDriversTransportReport([FromQuery] GetDriversByTransportModelsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddDriverCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateDriverCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteDriverCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
