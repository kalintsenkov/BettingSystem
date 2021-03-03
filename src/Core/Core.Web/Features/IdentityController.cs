namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Identity.Commands;
    using Application.Identity.Commands.LoginUser;
    using Application.Identity.Commands.RegisterUser;
    using Common;
    using Microsoft.AspNetCore.Mvc;

    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(
            RegisterUserCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<UserResponseModel>> Login(
            LoginUserCommand command)
            => await this.Send(command);
    }
}
