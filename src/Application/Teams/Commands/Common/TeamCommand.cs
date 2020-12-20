namespace BettingSystem.Application.Teams.Commands.Common
{
    using Application.Common;

    public abstract class TeamCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;
    }
}
