namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Competitions.Tournaments.Commands.Create;
    using Common;
    using Microsoft.AspNetCore.Mvc;

    [AuthorizeAdministrator]
    public class TournamentsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateTournamentResponseModel>> Create(
            CreateTournamentCommand command)
            => await this.Send(command);
    }
}
