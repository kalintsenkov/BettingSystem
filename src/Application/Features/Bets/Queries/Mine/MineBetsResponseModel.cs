namespace BettingSystem.Application.Features.Bets.Queries.Mine
{
    using AutoMapper;
    using Details;
    using Domain.Models.Bets;

    public class MineBetsResponseModel : BetDetailsResponseModel
    {
        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Bet, MineBetsResponseModel>()
                .IncludeBase<Bet, BetDetailsResponseModel>();
    }
}
