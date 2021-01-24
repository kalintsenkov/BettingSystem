namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using Domain.Competitions.Models.Leagues;

    internal class LeagueData : IMapFrom<League>, IMapTo<League>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public ICollection<TeamData> Teams { get; } = new HashSet<TeamData>();
    }
}
