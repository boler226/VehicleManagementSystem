using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Person.Add;
using VehicleManagementSystem.Application.Commands.Person.Delete;
using VehicleManagementSystem.Application.Commands.Person.Update;
using VehicleManagementSystem.Application.Queries.Person.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class PersonsController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllPersonsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddPersonCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePersonCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeletePersonCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
