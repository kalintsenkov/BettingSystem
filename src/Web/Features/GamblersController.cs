namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Features.Gambler.Commands.Edit;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class GamblersController : ApiController
    {
        [HttpPut(Id)]
        public Task<ActionResult> Edit(
            int id, EditGamblerCommand command)
            => this.Send(command.SetId(id));
    }
}
