namespace BettingSystem.Infrastructure.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using Application.Competitions.Leagues.Queries.Standings;
    using AutoMapper;
    using Domain.Teams.Models;

    internal class TeamData :
        IMapFrom<Domain.Teams.Models.Team>,
        IMapTo<Domain.Teams.Models.Team>,
        IMapFrom<Domain.Competitions.Models.Leagues.Team>,
        IMapTo<Domain.Competitions.Models.Leagues.Team>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int Points { get; set; }

        public int LeagueId { get; set; }

        public LeagueData League { get; set; } = default!;

        public ICollection<Player> Players { get; } = new HashSet<Player>();

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<
                    TeamData,
                    Domain.Teams.Models.Team>()
                .ReverseMap();

            mapper
                .CreateMap<
                    TeamData,
                    Domain.Competitions.Models.Leagues.Team>()
                .ReverseMap();

            mapper
                .CreateMap<
                    TeamData,
                    GetStandingsResponseModel>();
        }
    }
}
