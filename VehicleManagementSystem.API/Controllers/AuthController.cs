using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.Commands.Auth.Delete;
using VehicleManagementSystem.Application.Commands.Auth.Login;
using VehicleManagementSystem.Application.Commands.Auth.Register;
using VehicleManagementSystem.Application.Commands.Auth.Update;
using VehicleManagementSystem.Application.Queries.Auth.GetAll;
using VehicleManagementSystem.Domain.Entities.Identity;

namespace VehicleManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize(Roles = "AdminSD")]
    public async Task<ActionResult<List<UserEntity>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllUsersCommand(), cancellationToken);
        return Ok(result);
    }

    [HttpPost("register")]
    [Authorize(Roles = "Guest,AdminSD")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "AdminSD")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "AdminSD")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateUserCommand(id, command.UserName, command.Email, command.FullName, command.Role), cancellationToken);
        return NoContent();
    }
}