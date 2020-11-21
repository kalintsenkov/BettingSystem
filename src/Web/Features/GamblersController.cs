namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Features.Gambler.Commands.Edit;
    using Application.Features.Gambler.Queries.Details;
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
