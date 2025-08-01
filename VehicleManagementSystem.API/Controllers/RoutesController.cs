using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Route.Add;
using VehicleManagementSystem.Application.Commands.Route.Delete;
using VehicleManagementSystem.Application.Commands.Route.Update;
using VehicleManagementSystem.Application.Queries.Route.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RoutesController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
          Ok(await mediator.Send(new GetAllRoutesQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddRouteCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRouteCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRouteCommand command) =>
            Ok(await mediator.Send(command));
    }
}
