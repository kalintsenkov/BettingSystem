namespace BettingSystem.Application.Teams.Commands.Create
{
    using Common;
    using FluentValidation;

    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            this.Include(new TeamCommandValidator<CreateTeamCommand>());

            this.RuleFor(t => t.LeagueId)
                .NotEmpty();
        }
    }
}
