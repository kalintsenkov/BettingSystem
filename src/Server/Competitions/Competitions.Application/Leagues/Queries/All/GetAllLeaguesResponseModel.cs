namespace BettingSystem.Application.Competitions.Leagues.Queries.All;

using Common.Mapping;
using Domain.Competitions.Models.Leagues;

public class GetAllLeaguesResponseModel : IMapFrom<League>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;
}