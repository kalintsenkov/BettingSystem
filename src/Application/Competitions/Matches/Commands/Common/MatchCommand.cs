namespace BettingSystem.Application.Competitions.Matches.Commands.Common
{
    using System;
    using Application.Common;

    public abstract class MatchCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public DateTime StartDate { get; set; }

        public string HomeTeam { get; set; } = default!;

        public string AwayTeam { get; set; } = default!;

        public string StadiumName { get; set; } = default!;

        public string StadiumImageUrl { get; set; } = default!;
    }
}
