namespace BettingSystem.Application.Games.Matches.Queries.Stadiums
{
    using Application.Common.Mapping;
    using Domain.Games.Models.Matches;

    public class GetMatchStadiumsResponseModel : IMapFrom<Stadium>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;
    }
}
