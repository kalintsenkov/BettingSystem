namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Betting.Models.Bets;

    internal class BetData : IMapFrom<Bet>
    {
        public int Id { get; set; }

        public int MatchId { get; set; }

        public MatchData Match { get; set; } = default!;

        public int GamblerId { get; set; }

        public GamblerData Gambler { get; set; } = default!;

        public decimal Amount { get; set; }

        public Prediction Prediction { get; set; } = default!;

        public bool IsProfitable { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<BetData, Bet>()
                .ReverseMap();
    }
}
