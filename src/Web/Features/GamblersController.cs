namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Betting.Gamblers.Commands.Edit;
    using Application.Betting.Gamblers.Queries.Details;
    using Application.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class GamblersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public Task<ActionResult<GamblerDetailsResponseModel>> Details(
            [FromRoute] GamblerDetailsQuery query)
            => this.Send(query);

        [HttpPut]
        [Route(Id)]
        [Authorize]
        public Task<ActionResult> Edit(
            int id, EditGamblerCommand command)
            => this.Send(command.SetId(id));
    }
}
