using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Transport.AddTransport;
using VehicleManagementSystem.Application.Commands.Transport.DeleteTransport;
using VehicleManagementSystem.Application.Commands.Transport.Update;
using VehicleManagementSystem.Application.Queries.Transport.GetAll;

namespace VehicleManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransportController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await mediator.Send(new GetAllTransportsQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddTransportCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTransportCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) =>
            Ok(await mediator.Send(new DeleteTransportCommand(id)));
    } 
}
