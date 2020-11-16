namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Features.Matches.Commands.Create;
    using Application.Features.Matches.Queries.Details;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MatchesController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<MatchDetailsResponseModel>> Details(
            [FromRoute] MatchDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateMatchResponseModel>> Create(
            CreateMatchCommand command)
            => await this.Send(command);
    }
}
