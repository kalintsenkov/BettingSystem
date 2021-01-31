namespace BettingSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Matches.Commands.Cancel;
    using Application.Matches.Commands.Create;
    using Application.Matches.Commands.Delete;
    using Application.Matches.Commands.Edit;
    using Application.Matches.Commands.Finish;
    using Application.Matches.Commands.FirstHalf;
    using Application.Matches.Commands.HalfTime;
    using Application.Matches.Commands.SecondHalf;
    using Application.Matches.Queries.Details;
    using Application.Matches.Queries.Search;
    using Application.Matches.Queries.Stadiums;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AuthorizeAdministrator]
    public class MatchesController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<SearchMatchesResponseModel>> Search(
            [FromQuery] SearchMatchesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        [AllowAnonymous]
        public async Task<ActionResult<MatchDetailsResponseModel>> Details(
            [FromRoute] MatchDetailsQuery query)
            => await this.Send(query);

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Stadiums))]
        public async Task<ActionResult<IEnumerable<GetMatchStadiumsResponseModel>>> Stadiums(
            [FromQuery] GetMatchStadiumsQuery query)
            => await this.Send(query);

        [HttpPost]
        public async Task<ActionResult<CreateMatchResponseModel>> Create(
            [FromForm] CreateMatchCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditMatchCommand command)
            => await this.Send(command.SetId(id));

        [HttpPut]
        [Route(Id + PathSeparator + nameof(StartFirstHalf))]
        public async Task<ActionResult> StartFirstHalf(
            [FromRoute] StartMatchFirstHalfCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(HalfTime))]
        public async Task<ActionResult> HalfTime(
            [FromRoute] MatchHalfTimeCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(StartSecondHalf))]
        public async Task<ActionResult> StartSecondHalf(
            [FromRoute] StartMatchSecondHalfCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(Finish))]
        public async Task<ActionResult> Finish(
            [FromRoute] FinishMatchCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(Cancel))]
        public async Task<ActionResult> Cancel(
            [FromRoute] CancelMatchCommand command)
            => await this.Send(command);

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteMatchCommand command)
            => await this.Send(command);
    }
}
