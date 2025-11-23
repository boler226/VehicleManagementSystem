using FluentValidation;
using VehicleManagementSystem.Application.Commands.Auth.Register;

namespace VehicleManagementSystem.Application.Validators.Auth;
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required")
            .MinimumLength(3).WithMessage("UserName must be at least 3 characters long");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Role is required");
    }
}