namespace BettingSystem.Application.Competitions.Leagues.Queries.Standings;

using Common.Mapping;
using Domain.Competitions.Models.Teams;

public class GetStandingsResponseModel : IMapFrom<Team>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;

    public int Points { get; private set; }
}