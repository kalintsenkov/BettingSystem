namespace BettingSystem.Web.Competitions.Features
{
    using System.Threading.Tasks;
    using Application.Competitions.Teams.Queries.Details;
    using Common;
    using Microsoft.AspNetCore.Mvc;

    public class TeamsController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<TeamDetailsResponseModel?>> Details(
            [FromRoute] TeamDetailsQuery query)
            => await this.Send(query);
    }
}
