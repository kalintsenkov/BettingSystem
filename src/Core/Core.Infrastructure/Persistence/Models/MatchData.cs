namespace BettingSystem.Infrastructure.Persistence.Models
{
    using System;
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using AutoMapper;

    internal class MatchData :
        IMapFrom<Domain.Betting.Models.Matches.Match>,
        IMapTo<Domain.Betting.Models.Matches.Match>,
        IMapFrom<Domain.Matches.Models.Match>,
        IMapTo<Domain.Matches.Models.Match>
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public int HomeTeamId { get; set; }

        public TeamData HomeTeam { get; set; } = default!;

        public int AwayTeamId { get; set; }

        public TeamData AwayTeam { get; set; } = default!;

        public int StadiumId { get; set; }

        public StadiumData Stadium { get; set; } = default!;

        public StatisticsData Statistics { get; set; } = default!;

        public StatusData Status { get; set; } = default!;

        public ICollection<BetData> Bets { get; } = new HashSet<BetData>();

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<
                    MatchData,
                    Domain.Betting.Models.Matches.Match>()
                .ReverseMap();

            mapper
                .CreateMap<
                    MatchData,
                    Domain.Matches.Models.Match>()
                .ReverseMap();
        }
    }
}
