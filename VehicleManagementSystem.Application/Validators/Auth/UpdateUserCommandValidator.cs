using FluentValidation;
using VehicleManagementSystem.Application.Commands.Auth.Update;

namespace VehicleManagementSystem.Application.Validators.Auth;
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required")
            .MinimumLength(3).WithMessage("UserName must be at least 3 characters long");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required")
            .MinimumLength(2).WithMessage("FullName must be at least 2 characters long");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Role is required");
    }
}