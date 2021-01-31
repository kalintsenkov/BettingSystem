namespace BettingSystem.Application.Matches.Commands.Create
{
    using Common;
    using FluentValidation;

    public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchCommandValidator()
            => this.Include(new MatchCommandValidator<CreateMatchCommand>());
    }
}
