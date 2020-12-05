namespace BettingSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Betting.Matches.Commands.Cancel;
    using Application.Betting.Matches.Commands.Create;
    using Application.Betting.Matches.Commands.Delete;
    using Application.Betting.Matches.Commands.Edit;
    using Application.Betting.Matches.Commands.Finish;
    using Application.Betting.Matches.Commands.HalfTime;
    using Application.Betting.Matches.Commands.SecondHalf;
    using Application.Betting.Matches.Commands.Start;
    using Application.Betting.Matches.Queries.Details;
    using Application.Betting.Matches.Queries.Search;
    using Application.Betting.Matches.Queries.Stadiums;
    using Application.Betting.Matches.Queries.Teams;
    using Application.Common;
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

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Teams))]
        public async Task<ActionResult<IEnumerable<GetMatchTeamsResponseModel>>> Teams(
            [FromQuery] GetMatchTeamsQuery query)
            => await this.Send(query);

        [HttpPost]
        public async Task<ActionResult<CreateMatchResponseModel>> Create(
            CreateMatchCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditMatchCommand command)
            => await this.Send(command.SetId(id));

        [HttpPut]
        [Route(Id + PathSeparator + nameof(Start))]
        public async Task<ActionResult> Start(
            [FromRoute] StartMatchCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(HalfTime))]
        public async Task<ActionResult> HalfTime(
            [FromRoute] MatchHalfTimeCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id + PathSeparator + nameof(SecondHalf))]
        public async Task<ActionResult> SecondHalf(
            [FromRoute] MatchSecondHalfCommand command)
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
