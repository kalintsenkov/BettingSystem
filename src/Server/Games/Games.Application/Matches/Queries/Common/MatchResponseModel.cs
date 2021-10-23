namespace BettingSystem.Application.Games.Matches.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Games.Models.Matches;

    public class MatchResponseModel : IMapFrom<Match>
    {
        public int Id { get; private set; }

        public string StartDate { get; private set; } = default!;

        public int HomeTeamId { get; private set; }

        public int AwayTeamId { get; private set; }

        public string HomeTeamName { get; private set; } = default!;

        public string AwayTeamName { get; private set; } = default!;

        public int? HomeTeamScore { get; private set; }

        public int? AwayTeamScore { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Match, MatchResponseModel>()
                .ForMember(m => m.StartDate, cfg => cfg
                    .MapFrom(m => m.StartDate.ToString("HH:mm MM/dd/yyyy")))
                .ForMember(m => m.HomeTeamScore, cfg => cfg
                    .MapFrom(m => m.Statistics.HomeScore))
                .ForMember(m => m.AwayTeamScore, cfg => cfg
                    .MapFrom(m => m.Statistics.AwayScore));
    }
}
