namespace BettingSystem.Application.Competitions.Teams.Queries.Details;

using Common.Mapping;
using Domain.Competitions.Models.Teams;

public class TeamDetailsResponseModel : IMapFrom<Team>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;

    public int Points { get; private set; }
}