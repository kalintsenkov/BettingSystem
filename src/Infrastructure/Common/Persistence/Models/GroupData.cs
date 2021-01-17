namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using Domain.Championships.Models.Groups;

    internal class GroupData : IMapFrom<Group>, IMapTo<Group>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int TournamentId { get; set; }

        public TournamentData Tournament { get; set; } = default!;

        public ICollection<MatchData> Matches { get; } = new HashSet<MatchData>();
    }
}
