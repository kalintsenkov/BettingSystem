namespace BettingSystem.Application.Features.Matches.Queries.Details
{
    using Domain.Models.Matches;
    using Mapping;

    public class MatchDetailsResponseModel : IMapFrom<Match>
    {
        public string StartDate { get; private set; } = default!;

        public string HomeTeamName { get; private set; } = default!;

        public string AwayTeamName { get; private set; } = default!;

        public string StadiumName { get; private set; } = default!;

        public string StadiumImageUrl { get; private set; } = default!;

        public int? StatisticsHomeScore { get; private set; }

        public int? StatisticsAwayScore { get; private set; }
    }
}
