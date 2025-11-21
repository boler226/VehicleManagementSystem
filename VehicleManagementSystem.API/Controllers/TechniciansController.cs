using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Technician.Add;
using VehicleManagementSystem.Application.Commands.Technician.Delete;
using VehicleManagementSystem.Application.Commands.Technician.Update;
using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Application.Queries.Technician.GetAll;
using VehicleManagementSystem.Application.Queries.Technician.GetWorks;

namespace VehicleManagementSystem.API.Controllers; 
[ApiController]
[Route("api/[controller]")]
public class TechniciansController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetAllTechniciansQuery());
        return Ok(result);
    }

    [HttpGet("{technicianId}/works-report")]
    public async Task<IActionResult> GetWorksReport(
        Guid technicianId,
        [FromQuery] DateTime fromDate,
        [FromQuery] DateTime toDate,
        [FromQuery] Guid? transportId)
    {
        var result = await mediator.Send(new GetTechnicianWorksReportQuery(technicianId, fromDate, toDate, transportId));
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
