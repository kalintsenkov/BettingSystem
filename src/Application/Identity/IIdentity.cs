namespace BettingSystem.Application.Identity
{
    using System.Threading.Tasks;
    using Commands;
    using Commands.LoginUser;
    using Common;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserRequestModel userRequest);

        Task<Result<LoginSuccessModel>> Login(UserRequestModel userRequest);
    }
}
