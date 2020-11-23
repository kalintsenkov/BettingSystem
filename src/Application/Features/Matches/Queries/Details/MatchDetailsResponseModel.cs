namespace BettingSystem.Application.Features.Matches.Queries.Details
{
    using AutoMapper;
    using Common;
    using Domain.Models.Matches;

    public class MatchDetailsResponseModel : MatchResponseModel
    {
        public string StadiumName { get; private set; } = default!;

        public string StadiumImageUrl { get; private set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Match, MatchDetailsResponseModel>()
                .IncludeBase<Match, MatchResponseModel>();
    }
}
