namespace BettingSystem.Application.Identity.Commands.LoginUser
{
    public class LoginSuccessModel
    {
        public LoginSuccessModel(string token, string userId)
        {
            this.Token = token;
            this.UserId = userId;
        }

        public string Token { get; }

        public string UserId { get; }
    }
}
