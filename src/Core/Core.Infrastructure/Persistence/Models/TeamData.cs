namespace BettingSystem.Infrastructure.Persistence.Models
{
    using Application.Common.Mapping;
    using Application.Competitions.Leagues.Queries.Standings;
    using AutoMapper;

    internal class TeamData :
        IMapFrom<Domain.Competitions.Models.Leagues.Team>,
        IMapTo<Domain.Competitions.Models.Leagues.Team>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int Points { get; set; }

        public int LeagueId { get; set; }

        public LeagueData League { get; set; } = default!;

        public void Mapping(Profile mapper)
        {
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
