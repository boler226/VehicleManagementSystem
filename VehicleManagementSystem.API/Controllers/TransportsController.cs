using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Transport.AddTransport;
using VehicleManagementSystem.Application.Commands.Transport.DeleteTransport;
using VehicleManagementSystem.Application.Commands.Transport.Update;
using VehicleManagementSystem.Application.Queries.Transport.GetAll;
using VehicleManagementSystem.Application.Queries.Transport.GetCargoReport;
using VehicleManagementSystem.Application.Queries.Transport.GettAcquisitionWriteOff;
using VehicleManagementSystem.Application.Queries.TransportRepair.GetStats;

namespace VehicleManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransportsController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Guest,Authorised,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTransportsQuery());
        return Ok(result);
    }

    [HttpGet("cargo-report")]
    [Authorize(Roles = "Authorised,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetCargoReport([FromQuery] GetCargoTransportReportQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("acquisition-writeoff")]
    [Authorize(Roles = "Authorised,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetAcquisitionWriteOff([FromQuery] GetTransportAcquisitionWriteOffQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("repair-stats")]
    [Authorize(Roles = "Authorised,OperatorSD,AdminSD")]
    public async Task<IActionResult> GetRepairStats([FromQuery] GetTransportRepairStatsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Add(AddTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Update(UpdateTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "OperatorSD,AdminSD")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteTransportCommand(id));
        return Ok(result);
    }
} 
