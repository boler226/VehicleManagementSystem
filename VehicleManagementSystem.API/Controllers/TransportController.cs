using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.AddTransport;
using VehicleManagementSystem.Application.Queries.GetAllTransports;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransportController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await mediator.Send(new GetAllTransportsQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddTransportCommand command) =>
            Ok(await mediator.Send(command));
    }
}
