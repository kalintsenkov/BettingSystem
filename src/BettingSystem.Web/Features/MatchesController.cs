namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Features.Matches.Queries.Details;
    using Microsoft.AspNetCore.Mvc;

    public class MatchesController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<MatchDetailsResponseModel>> Details(
            [FromRoute] MatchDetailsQuery query)
            => await this.Send(query);
    }
}
