namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Features.Bets.Commands.Close;
    using Application.Features.Bets.Commands.Create;
    using Application.Features.Bets.Commands.MakeProfitable;
    using Application.Features.Bets.Queries.Details;
    using Application.Features.Bets.Queries.Mine;
    using Application.Features.Bets.Queries.Search;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BetsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchBetsResponseModel>> Search(
            [FromQuery] SearchBetsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineBetsResponseModel>> Mine(
            [FromQuery] MineBetsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<BetDetailsResponseModel>> Details(
            [FromRoute] BetDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        public async Task<ActionResult<CreateBetResponseModel>> Create(
            CreateBetCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        [AuthorizeAdministrator]
        public async Task<ActionResult> MakeProfitable(
            [FromRoute] MakeBetProfitableCommand command)
            => await this.Send(command);

        [HttpDelete]
        [Route(Id)]
        [AuthorizeAdministrator]
        public async Task<ActionResult> Close(
            [FromRoute] CloseBetCommand command)
            => await this.Send(command);
    }
}
