namespace BettingSystem.Application.Identity.Commands.ChangePassword;

public class ChangePasswordRequestModel
{
    public ChangePasswordRequestModel(
        string userId,
        string currentPassword,
        string newPassword)
    {
        this.UserId = userId;
        this.CurrentPassword = currentPassword;
        this.NewPassword = newPassword;
    }

    public string UserId { get; }

    public string CurrentPassword { get; }

    public string NewPassword { get; }
}