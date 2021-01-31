namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Teams.Models;

    internal class TeamData :
        IMapFrom<Domain.Betting.Models.Matches.Team>,
        IMapTo<Domain.Betting.Models.Matches.Team>,
        IMapFrom<Domain.Teams.Models.Team>,
        IMapTo<Domain.Teams.Models.Team>,
        IMapFrom<Domain.Matches.Models.Team>,
        IMapTo<Domain.Matches.Models.Team>
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
                    Domain.Betting.Models.Matches.Team>()
                .ReverseMap();

            mapper
                .CreateMap<
                    TeamData,
                    Domain.Teams.Models.Team>()
                .ReverseMap();

            mapper
                .CreateMap<
                    TeamData,
                    Domain.Matches.Models.Team>()
                .ReverseMap();
        }
    }
}
