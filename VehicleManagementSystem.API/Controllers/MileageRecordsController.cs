using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.MileageRecord.Add;
using VehicleManagementSystem.Application.Commands.MileageRecord.Delete;
using VehicleManagementSystem.Application.Commands.MileageRecord.Update;
using VehicleManagementSystem.Application.Queries.MileageRecord.GetAll;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]/[action]")]
public class MileageRecordsController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllMileageRecordsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddMileageRecordCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateMileageRecordCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteMileageRecordCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
