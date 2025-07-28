using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.DriverTransport.Add;
using VehicleManagementSystem.Application.Commands.DriverTransport.Delete;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DriverTransportsController(IMediator mediator) : ControllerBase {
        [HttpPost]
        public async Task<IActionResult> Add(AddDriverTransportCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDriverTransportCommand command) =>
            Ok(await mediator.Send(command));
    }
}
