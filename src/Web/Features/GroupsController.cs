namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Championships.Groups.Commands.Create;
    using Application.Championships.Groups.Commands.Edit;
    using Application.Common;
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
