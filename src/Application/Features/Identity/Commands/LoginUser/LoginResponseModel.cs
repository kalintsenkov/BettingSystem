namespace BettingSystem.Application.Features.Identity.Commands.LoginUser
{
    public class LoginResponseModel
    {
        public LoginResponseModel(string token) => this.Token = token;

        public string Token { get; }
    }
}
