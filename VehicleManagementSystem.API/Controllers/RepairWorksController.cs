using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.RepairWork.Add;
using VehicleManagementSystem.Application.Commands.RepairWork.Delete;
using VehicleManagementSystem.Application.Commands.RepairWork.Update;
using VehicleManagementSystem.Application.Queries.RepairWork.GetAll;

namespace VehicleManagementSystem.API.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class RepairWorksController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Guest,Authorized,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllRepairWorksQuery());
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Add(AddRepairWorkCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Update(UpdateRepairWorkCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Delete(DeleteRepairWorkCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
