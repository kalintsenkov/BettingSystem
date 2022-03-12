namespace BettingSystem.Application.Competitions.Leagues.Commands.Edit;

using Common;
using FluentValidation;

public class EditLeagueCommandValidator : AbstractValidator<EditLeagueCommand>
{
    public EditLeagueCommandValidator()
        => this.Include(new LeagueCommandValidator<EditLeagueCommand>());
}