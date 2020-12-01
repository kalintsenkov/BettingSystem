namespace BettingSystem.Application.Betting.Matches.Queries.Teams
{
    using Application.Common.Mapping;
    using Domain.Betting.Models.Matches;

    public class GetMatchTeamsResponseModel : IMapFrom<Team>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;
    }
}
