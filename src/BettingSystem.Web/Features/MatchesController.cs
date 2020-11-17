namespace BettingSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Features.Matches.Commands.Create;
    using Application.Features.Matches.Commands.Edit;
    using Application.Features.Matches.Queries.Details;
    using Application.Features.Matches.Queries.Stadiums;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MatchesController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<MatchDetailsResponseModel>> Details(
            [FromRoute] MatchDetailsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(nameof(Stadiums))]
        public async Task<ActionResult<IEnumerable<GetMatchStadiumsResponseModel>>> Stadiums(
            [FromQuery] GetMatchStadiumsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateMatchResponseModel>> Create(
            CreateMatchCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult> Edit(
            int id, EditMatchCommand command)
            => await this.Send(command.SetId(id));
    }
}
