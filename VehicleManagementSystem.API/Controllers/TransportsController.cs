using MediatR;
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
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTransportsQuery());
        return Ok(result);
    }

    [HttpGet("cargo-report")]
    public async Task<IActionResult> GetCargoReport([FromQuery] GetCargoTransportReportQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("acquisition-writeoff")] 
    public async Task<IActionResult> GetAcquisitionWriteOff([FromQuery] GetTransportAcquisitionWriteOffQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("repair-stats")]
    public async Task<IActionResult> GetRepairStats([FromQuery] GetTransportRepairStatsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTransportCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteTransportCommand(id));
        return Ok(result);
    }
} 
