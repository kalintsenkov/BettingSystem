namespace BettingSystem.Application.Contracts
{
    using System.Threading.Tasks;
    using Common;
    using Features.Identity;

    public interface IIdentity
    {
        Task<Result> Register(UserRequestModel userRequest);

        Task<Result<LoginResponseModel>> Login(UserRequestModel userRequest);
    }
}
