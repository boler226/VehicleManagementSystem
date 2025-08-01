using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.RouteAssignment.Add;
using VehicleManagementSystem.Application.Commands.RouteAssignment.Delete;
using VehicleManagementSystem.Application.Commands.RouteAssignment.Update;
using VehicleManagementSystem.Application.Queries.RouteAssignment.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RouteAssignmentsController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
         Ok(await mediator.Send(new GetAllRouteAssignmentsQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddRouteAssignmentCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRouteAssignmentCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRouteAssignmentCommand command) =>
            Ok(await mediator.Send(command));
    }
}
