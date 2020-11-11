namespace BettingSystem.Application.Contracts
{
    using System.Threading.Tasks;
    using Common;
    using Features.Identity;
    using Features.Identity.Commands.LoginUser;

    public interface IIdentity
    {
        Task<Result> Register(UserRequestModel userRequest);

        Task<Result<LoginResponseModel>> Login(UserRequestModel userRequest);
    }
}
