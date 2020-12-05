namespace BettingSystem.Application.Identity.Commands.LoginUser
{
    public class LoginResponseModel
    {
        internal LoginResponseModel(string token, int gamblerId)
        {
            this.Token = token;
            this.GamblerId = gamblerId;
        }

        public string Token { get; }

        public int GamblerId { get; }
    }
}
