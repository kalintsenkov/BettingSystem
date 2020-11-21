namespace BettingSystem.Application.Features.Matches.Commands.Create
{
    using System;
    using FluentValidation;

    using static Domain.Models.ModelConstants.Common;

    public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchCommandValidator()
        {
            this.RuleFor(m => m.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today);

            this.RuleFor(m => m.HomeTeam)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(m => m.AwayTeam)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(m => m.StadiumName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(m => m.StadiumImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();
        }
    }
}
