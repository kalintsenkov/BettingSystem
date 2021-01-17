namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Competitions.Groups.Commands.Create;
    using Application.Competitions.Groups.Commands.Edit;
    using Common;
    using Microsoft.AspNetCore.Mvc;

    [AuthorizeAdministrator]
    public class GroupsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateGroupResponseModel>> Create(
            CreateGroupCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditGroupCommand command)
            => await this.Send(command.SetId(id));
    }
}
