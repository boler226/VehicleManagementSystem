using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.MileageRecord.Add;
using VehicleManagementSystem.Application.Commands.MileageRecord.Delete;
using VehicleManagementSystem.Application.Commands.MileageRecord.Update;
using VehicleManagementSystem.Application.DTOs.MileageRecord;
using VehicleManagementSystem.Application.Queries.MileageRecord.GetAll;
using VehicleManagementSystem.Application.Queries.MileageRecord.GetByDate;

namespace VehicleManagementSystem.API.Controllers; 

[ApiController]
[Route("api/[controller]")]
public class MileageRecordsController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Guest,Authorised,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllMileageRecordsQuery());
        return Ok(result);
    }

    [HttpGet("milieage-records")]
    [Authorize(Roles = "Authorised,OperatorSD,AdminSD")]
    public async Task<ActionResult<List<MileageRecordDto>>> GetMileageRecords([FromQuery] GetMileageRecordByDateQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Add(AddMileageRecordCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Update(UpdateMileageRecordCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Delete(DeleteMileageRecordCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
