namespace BettingSystem.Application.Betting.Gamblers.Queries.Details
{
    using System.Linq;
    using AutoMapper;
    using Domain.Betting.Models.Gamblers;

    public class GamblerDetailsResponseModel
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public int TotalWins { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Gambler, GamblerDetailsResponseModel>()
                .ForMember(m => m.TotalWins, cfg => cfg
                    .MapFrom(g => g.Bets
                        .Count(b => b.IsProfitable)));
    }
}
