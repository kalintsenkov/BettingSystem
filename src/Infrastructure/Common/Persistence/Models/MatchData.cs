namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using System;
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using AutoMapper;

    internal class MatchData :
        IMapFrom<Domain.Betting.Models.Matches.Match>,
        IMapTo<Domain.Betting.Models.Matches.Match>,
        IMapFrom<Domain.Championships.Models.Matches.Match>,
        IMapTo<Domain.Championships.Models.Matches.Match>
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public int HomeTeamId { get; set; }

        public TeamData HomeTeam { get; set; } = default!;

        public int AwayTeamId { get; set; }

        public TeamData AwayTeam { get; set; } = default!;

        public int StadiumId { get; set; }

        public StadiumData Stadium { get; set; } = default!;

        public int? GroupId { get; set; }

        public GroupData Group { get; set; } = default!;

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
                    Domain.Championships.Models.Matches.Match>()
                .ReverseMap();
        }
    }
}
