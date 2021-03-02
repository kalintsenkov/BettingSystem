namespace BettingSystem.Infrastructure.Persistence.Models
{
    using Application.Common.Mapping;
    using AutoMapper;

    internal class StatisticsData :
        IMapFrom<Domain.Betting.Models.Matches.Statistics>,
        IMapTo<Domain.Betting.Models.Matches.Statistics>,
        IMapFrom<Domain.Matches.Models.Statistics>,
        IMapTo<Domain.Matches.Models.Statistics>
    {
        public int? HomeScore { get; set; }

        public int? AwayScore { get; set; }

        public int? HalfTimeHomeScore { get; set; }

        public int? HalfTimeAwayScore { get; set; }

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<
                    StatisticsData,
                    Domain.Betting.Models.Matches.Statistics>()
                .ReverseMap();

            mapper
                .CreateMap<
                    StatisticsData,
                    Domain.Matches.Models.Statistics>()
                .ReverseMap();
        }
    }
}
