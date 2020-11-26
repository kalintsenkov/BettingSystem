namespace BettingSystem.Application.Features.Bets.Queries.Mine
{
    using AutoMapper;
    using Details;
    using Domain.Models.Bets;

    public class MineBetResponseModel : BetDetailsResponseModel
    {
        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Bet, MineBetResponseModel>()
                .IncludeBase<Bet, BetDetailsResponseModel>();
    }
}
