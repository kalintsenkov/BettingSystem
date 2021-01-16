namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using Application.Teams.Queries.All;
    using AutoMapper;
    using Domain.Teams.Models;

    internal class TeamData :
        IMapFrom<Domain.Betting.Models.Matches.Team>,
        IMapTo<Domain.Betting.Models.Matches.Team>,
        IMapFrom<Domain.Teams.Models.Team>,
        IMapTo<Domain.Teams.Models.Team>,
        IMapFrom<Domain.Tournaments.Models.Matches.Team>,
        IMapTo<Domain.Tournaments.Models.Matches.Team>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

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
                    Domain.Tournaments.Models.Matches.Team>()
                .ReverseMap();
        }
    }
}
