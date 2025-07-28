using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Technician.Add;
using VehicleManagementSystem.Application.Commands.Technician.Delete;
using VehicleManagementSystem.Application.Commands.Technician.Update;
using VehicleManagementSystem.Application.Queries.Technician.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TechniciansController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
          Ok(await mediator.Send(new GetAllTechniciansQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddTechnicianCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTechnicianCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteTechnicianCommand command) =>
            Ok(await mediator.Send(command));
    }
}
