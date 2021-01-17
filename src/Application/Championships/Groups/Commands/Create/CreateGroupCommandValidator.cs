namespace BettingSystem.Application.Championships.Groups.Commands.Create
{
    using Common;
    using FluentValidation;

    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
            => this.Include(new GroupCommandValidator<CreateGroupCommand>());
    }
}
