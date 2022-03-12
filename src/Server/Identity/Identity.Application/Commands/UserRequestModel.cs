namespace BettingSystem.Application.Identity.Commands;

public abstract class UserRequestModel
{
    protected UserRequestModel(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }

    public string Email { get; }

    public string Password { get; }
}