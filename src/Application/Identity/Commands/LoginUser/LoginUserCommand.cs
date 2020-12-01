namespace BettingSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
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

            public LoginUserCommandHandler(IIdentity identity) => this.identity = identity;

            public async Task<Result<LoginResponseModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
                => await this.identity.Login(request);
        }
    }
}
