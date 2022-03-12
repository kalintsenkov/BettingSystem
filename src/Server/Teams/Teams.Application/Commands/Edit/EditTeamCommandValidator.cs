namespace BettingSystem.Application.Teams.Commands.Edit;

using Common;
using FluentValidation;

public class EditTeamCommandValidator : AbstractValidator<EditTeamCommand>
{
    public EditTeamCommandValidator()
        => this.Include(new TeamCommandValidator<EditTeamCommand>());
}