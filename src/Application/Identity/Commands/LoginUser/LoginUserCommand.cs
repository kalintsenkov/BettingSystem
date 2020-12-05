namespace BettingSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Betting.Repositories;
    using MediatR;

    public class LoginUserCommand : UserRequestModel, IRequest<Result<LoginResponseModel>>
    {
        public LoginUserCommand(string email, string password)
            : base(email, password)
        {
        }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginResponseModel>>
        {
            private readonly IIdentity identity;
            private readonly IGamblerDomainRepository gamblerRepository;

            public LoginUserCommandHandler(
                IIdentity identity,
                IGamblerDomainRepository gamblerRepository)
            {
                this.identity = identity;
                this.gamblerRepository = gamblerRepository;
            }

            public async Task<Result<LoginResponseModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var gamblerId = await this.gamblerRepository.GetGamblerId(
                    user.UserId,
                    cancellationToken);

                return new LoginResponseModel(user.Token, gamblerId);
            }
        }
    }
}
