using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Team.Add;
using VehicleManagementSystem.Application.Commands.Team.Delete;
using VehicleManagementSystem.Application.Commands.Team.Update;
using VehicleManagementSystem.Application.Queries.Team.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeamsController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await mediator.Send(new GetAllTeamsQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddTeamCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeamCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteTeamCommand command) =>
            Ok(await mediator.Send(command));
    }
}
