namespace BettingSystem.Application.Features.Identity
{
    public class UserRequestModel
    {
        public UserRequestModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public string Email { get; }

        public string Password { get; }
    }
}
