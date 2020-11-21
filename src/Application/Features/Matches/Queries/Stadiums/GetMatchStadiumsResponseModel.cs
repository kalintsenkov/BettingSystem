namespace BettingSystem.Application.Features.Matches.Queries.Stadiums
{
    using Domain.Models.Matches;
    using Mapping;

    public class GetMatchStadiumsResponseModel : IMapFrom<Stadium>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;
    }
}
