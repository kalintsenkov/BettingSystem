namespace BettingSystem.Application.Matches.Queries.Stadiums
{
    using Application.Common.Mapping;
    using Domain.Matches.Models;

    public class GetMatchStadiumsResponseModel : IMapFrom<Stadium>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;
    }
}
