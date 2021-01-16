namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using Domain.Tournaments.Models.Tournaments;

    internal class TournamentData : IMapFrom<Tournament>, IMapTo<Tournament>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public ICollection<MatchData> Matches { get; } = new HashSet<MatchData>();
    }
}
