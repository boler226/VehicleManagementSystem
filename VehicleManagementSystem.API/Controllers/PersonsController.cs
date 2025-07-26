using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Person.Add;
using VehicleManagementSystem.Application.Commands.Person.Delete;
using VehicleManagementSystem.Application.Commands.Person.Update;
using VehicleManagementSystem.Application.Queries.Person.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonsController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
           Ok(await mediator.Send(new GetAllPersonsQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddPersonCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePersonCommand command) =>
            Ok(await mediator.Send(command));
    }
}
