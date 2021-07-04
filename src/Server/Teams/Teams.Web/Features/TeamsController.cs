namespace BettingSystem.Web.Teams.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Teams.Commands.AddPlayer;
    using Application.Teams.Commands.Create;
    using Application.Teams.Commands.Delete;
    using Application.Teams.Commands.Edit;
    using Application.Teams.Queries.All;
    using Application.Teams.Queries.Players;
    using Common;
    using Common.Attributes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AuthorizeAdministrator]
    public class TeamsController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GetAllTeamsResponseModel>>> All(
            [FromQuery] GetAllTeamsQuery query)
            => await this.Send(query);

        [HttpGet]
        [AllowAnonymous]
        [Route(Id + PathSeparator + nameof(Players))]
        public async Task<ActionResult<IEnumerable<GetTeamPlayersResponseModel>>> Players(
            [FromRoute] GetTeamPlayersQuery query)
            => await this.Send(query);

        [HttpPost]
        public async Task<ActionResult<CreateTeamResponseModel>> Create(
            CreateTeamCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditTeamCommand command)
            => await this.Send(command.SetId(id));

        [HttpPut]
        [Route(Id + PathSeparator + nameof(AddPlayer))]
        public async Task<ActionResult> AddPlayer(
            int id, AddPlayerCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteTeamCommand command)
            => await this.Send(command);
    }
}
