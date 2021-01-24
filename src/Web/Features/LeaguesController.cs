namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Competitions.Leagues.Commands.Create;
    using Application.Competitions.Leagues.Commands.Edit;
    using Common;
    using Microsoft.AspNetCore.Mvc;

    [AuthorizeAdministrator]
    public class LeaguesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateLeagueResponseModel>> Create(
            CreateLeagueCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditLeagueCommand command)
            => await this.Send(command.SetId(id));
    }
}
