using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.GarageObject.Add;
using VehicleManagementSystem.Application.Commands.GarageObject.Delete;
using VehicleManagementSystem.Application.Commands.GarageObject.Update;
using VehicleManagementSystem.Application.Queries.GarageObject.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GarageObjectsController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await mediator.Send(new GetAllGarageObjectQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddGarageObjectCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateGarageObjectCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteGarageObjectCommand command) =>
            Ok(await mediator.Send(command));
    }
}
