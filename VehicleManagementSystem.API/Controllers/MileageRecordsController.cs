using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.MileageRecord.Add;
using VehicleManagementSystem.Application.Commands.MileageRecord.Delete;
using VehicleManagementSystem.Application.Commands.MileageRecord.Update;
using VehicleManagementSystem.Application.Queries.MileageRecord.GetAll;

namespace VehicleManagementSystem.API.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MileageRecordsController(IMediator mediator) : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await mediator.Send(new GetAllMileageRecordsQuery()));

        [HttpPost]
        public async Task<IActionResult> Add(AddMileageRecordCommand command) =>
            Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMileageRecordCommand command) =>
            Ok(await mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteMileageRecordCommand command) =>
            Ok(await mediator.Send(command));
    }
}
