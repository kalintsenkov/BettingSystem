namespace BettingSystem.Application.Features.Identity.Commands.RegisterUser
{
    using FluentValidation;

    using static Domain.Models.ModelConstants.Common;
    using static Domain.Models.ModelConstants.Identity;

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MinimumLength(MinPasswordLength)
                .MaximumLength(MaxPasswordLength)
                .NotEmpty();

            this.RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password)
                .WithMessage("The password and confirmation password do not match.")
                .NotEmpty();
        }
    }
}
