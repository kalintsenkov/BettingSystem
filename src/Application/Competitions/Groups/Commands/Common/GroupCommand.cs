namespace BettingSystem.Application.Competitions.Groups.Commands.Common
{
    using Application.Common;

    public abstract class GroupCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;

        public int TournamentId { get; set; }
    }
}
