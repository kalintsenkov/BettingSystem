namespace BettingSystem.Application.Competitions.Leagues.Commands.Common
{
    using Application.Common;

    public abstract class LeagueCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;
    }
}
