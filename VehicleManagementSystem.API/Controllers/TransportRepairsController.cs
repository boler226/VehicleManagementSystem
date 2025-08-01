using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.TransportRepair.Add;
using VehicleManagementSystem.Application.Commands.TransportRepair.Delete;
using VehicleManagementSystem.Application.Commands.TransportRepair.Update;
using VehicleManagementSystem.Application.Queries.TransportRepair.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransportRepairsController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
         Ok(await mediator.Send(new GetAllTransportRepairsQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddTransportRepairCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTransportRepairCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteTransportRepairCommand command) =>
            Ok(await mediator.Send(command));
    }
}
