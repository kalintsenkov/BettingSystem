namespace BettingSystem.Infrastructure.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Betting.Gamblers.Queries.Details;
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Betting.Models.Gamblers;

    internal class GamblerData : IMapFrom<Gambler>, IMapTo<Gambler>, IMapTo<GamblerDetailsResponseModel>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string UserId { get; set; } = default!;

        public ICollection<BetData> Bets { get; } = new HashSet<BetData>();

        public void Mapping(Profile mapper)
        {
            mapper
                .CreateMap<Gambler, GamblerData>()
                .ReverseMap();

            mapper
                .CreateMap<GamblerData, GamblerDetailsResponseModel>();
        }
    }
}
