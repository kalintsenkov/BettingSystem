namespace BettingSystem.Application.Matches.Matches.Queries.Details
{
    using AutoMapper;
    using Common;
    using Domain.Common.Models;
    using Domain.Matches.Models.Matches;

    public class MatchDetailsResponseModel : MatchResponseModel
    {
        public string StadiumName { get; private set; } = default!;

        public string StadiumImageUrl { get; private set; } = default!;

        public string Status { get; private set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Match, MatchDetailsResponseModel>()
                .IncludeBase<Match, MatchResponseModel>()
                .ForMember(m => m.Status, cfg => cfg
                    .MapFrom(m => Enumeration.NameFromValue<Status>(
                        m.Status.Value)));
    }
}
