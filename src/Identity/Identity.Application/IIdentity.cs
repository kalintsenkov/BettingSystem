namespace BettingSystem.Application.Identity
{
    using System.Threading.Tasks;
    using Commands;
    using Commands.ChangePassword;
    using Common;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserRequestModel userRequest);

        Task<Result<UserResponseModel>> Login(UserRequestModel userRequest);

        Task<Result> ChangePassword(ChangePasswordRequestModel changePasswordRequest);
    }
}
