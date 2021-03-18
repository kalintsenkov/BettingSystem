namespace BettingSystem.Application.Competitions.Leagues.Queries.Standings
{
    using Common.Mapping;
    using Domain.Competitions.Models.Teams;

    public class GetStandingsResponseModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int Points { get; set; }
    }
}
