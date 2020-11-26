namespace BettingSystem.Application.Features.Bets.Queries.Mine
{
    using System.Collections.Generic;
    using Common;

    public class MineBetsResponseModel : BetListingsResponseModel<MineBetResponseModel>
    {
        internal MineBetsResponseModel(IEnumerable<MineBetResponseModel> bets)
            : base(bets)
        {
        }
    }
}
