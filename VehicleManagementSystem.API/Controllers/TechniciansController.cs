using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Technician.Add;
using VehicleManagementSystem.Application.Commands.Technician.Delete;
using VehicleManagementSystem.Application.Commands.Technician.Update;
using VehicleManagementSystem.Application.Queries.Technician.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class TechniciansController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTechniciansQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTechnicianCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTechnicianCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteTechnicianCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
