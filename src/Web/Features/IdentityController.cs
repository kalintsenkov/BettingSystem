namespace BettingSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Features.Identity.Commands.LoginUser;
    using Application.Features.Identity.Commands.RegisterUser;
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
        public async Task<ActionResult<LoginResponseModel>> Login(
            LoginUserCommand command)
            => await this.Send(command);
    }
}
