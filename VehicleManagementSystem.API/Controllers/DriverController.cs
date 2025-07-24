using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Driver.Add;
using VehicleManagementSystem.Application.Commands.Driver.Delete;
using VehicleManagementSystem.Application.Commands.Driver.Update;
using VehicleManagementSystem.Application.Queries.Driver.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DriverController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await mediator.Send(new GetAllDriversQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddDriverCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDriverCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDriverCommand command) =>
            Ok(await mediator.Send(command));
    }
}
