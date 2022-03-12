namespace BettingSystem.Application.Teams.Queries.All;

using Common.Mapping;
using Domain.Teams.Models;

public class GetAllTeamsResponseModel : IMapFrom<Team>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;
}