namespace BettingSystem.Application.Features.Bets.Queries.Details
{
    using AutoMapper;
    using Common;
    using Domain.Models.Bets;

    public class BetDetailsResponseModel : BetResponseModel
    {
        public bool IsProfitable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Bet, BetDetailsResponseModel>()
                .IncludeBase<Bet, BetResponseModel>();
    }
}
