using apptest.shared.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apptest.shared.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Not a valid email address");

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(30)
                .WithMessage("First name must be less than 30 characters");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MaximumLength(30)
                .WithMessage("Last name must be less than 30 characters");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(5)
                .WithMessage("Password must at least 5 characters");

            RuleFor(p => p.ConfirmPassword)
                .Equal(p => p.Password)
                .WithMessage("Confirm password doesn't match the password");

        }

    }
}
