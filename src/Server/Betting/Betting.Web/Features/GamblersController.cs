namespace BettingSystem.Web.Betting.Features
{
    using System.Threading.Tasks;
    using Application.Betting.Gamblers.Commands.Create;
    using Application.Betting.Gamblers.Commands.Edit;
    using Application.Betting.Gamblers.Queries.Details;
    using Application.Betting.Gamblers.Queries.GetId;
    using Application.Common;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class GamblersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public Task<ActionResult<GamblerDetailsResponseModel>> Details(
            [FromRoute] GamblerDetailsQuery query)
            => this.Send(query);

        [HttpGet]
        [Route(nameof(Id))]
        public Task<ActionResult<GetGamblerIdResponseModel>> GetGamblerId(
            [FromRoute] GetGamblerIdQuery query)
            => this.Send(query);

        [HttpPost]
        public async Task<ActionResult<CreateGamblerResponseModel>> Create(
            CreateGamblerCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public Task<ActionResult> Edit(
            int id, EditGamblerCommand command)
            => this.Send(command.SetId(id));
    }
}
