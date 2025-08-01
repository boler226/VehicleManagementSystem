using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.RepairWork.Add;
using VehicleManagementSystem.Application.Commands.RepairWork.Delete;
using VehicleManagementSystem.Application.Commands.RepairWork.Update;
using VehicleManagementSystem.Application.Queries.RepairWork.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RepairWorksController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
         Ok(await mediator.Send(new GetAllRepairWorksQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddRepairWorkCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRepairWorkCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRepairWorkCommand command) =>
            Ok(await mediator.Send(command));
    }
}
