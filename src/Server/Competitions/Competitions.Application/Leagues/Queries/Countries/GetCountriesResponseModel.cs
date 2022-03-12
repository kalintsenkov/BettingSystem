namespace BettingSystem.Application.Competitions.Leagues.Queries.Countries;

using Common.Mapping;
using Domain.Competitions.Models.Leagues;

public class GetCountriesResponseModel : IMapFrom<Country>
{
    public int Id { get; private set; }

    public string Name { get; private set; } = default!;
}