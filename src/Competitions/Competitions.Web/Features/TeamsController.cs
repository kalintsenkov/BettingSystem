namespace BettingSystem.Web.Competitions.Features
{
    using System.Threading.Tasks;
    using Application.Competitions.Teams.Commands.Create;
    using Common;
    using Common.Attributes;
    using Microsoft.AspNetCore.Mvc;

    [AuthorizeAdministrator]
    public class TeamsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateTeamResponseModel>> Create(
            CreateTeamCommand command)
            => await this.Send(command);
    }
}
