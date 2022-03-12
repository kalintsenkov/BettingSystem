namespace BettingSystem.Application.Competitions.Leagues.Commands.Create;

using Common;
using FluentValidation;

public class CreateLeagueCommandValidator : AbstractValidator<CreateLeagueCommand>
{
    public CreateLeagueCommandValidator()
        => this.Include(new LeagueCommandValidator<CreateLeagueCommand>());
}