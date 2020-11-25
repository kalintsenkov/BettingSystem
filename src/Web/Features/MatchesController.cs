namespace BettingSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Features.Matches.Commands.Cancel;
    using Application.Features.Matches.Commands.Create;
    using Application.Features.Matches.Commands.Delete;
    using Application.Features.Matches.Commands.Edit;
    using Application.Features.Matches.Commands.Finish;
    using Application.Features.Matches.Commands.Start;
    using Application.Features.Matches.Queries.Details;
    using Application.Features.Matches.Queries.Search;
    using Application.Features.Matches.Queries.Stadiums;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MatchesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchMatchesResponseModel>> Search(
            [FromQuery] SearchMatchesQuery query)
            => await this.Send(query);

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
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditMatchCommand command)
            => await this.Send(command.SetId(id));

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(Start))]
        public async Task<ActionResult> Start(
            [FromRoute] StartMatchCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(Finish))]
        public async Task<ActionResult> Finish(
            [FromRoute] FinishMatchCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(Cancel))]
        public async Task<ActionResult> Cancel(
            [FromRoute] CancelMatchCommand command)
            => await this.Send(command);

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteMatchCommand command)
            => await this.Send(command);
    }
}
