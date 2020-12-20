namespace BettingSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Teams.Commands.Create;
    using Application.Teams.Commands.Edit;
    using Application.Teams.Queries.All;
    using Common;
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

        [HttpPost]
        public async Task<ActionResult<CreateTeamResponseModel>> Create(
            CreateTeamCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditTeamCommand command)
            => await this.Send(command.SetId(id));
    }
}
