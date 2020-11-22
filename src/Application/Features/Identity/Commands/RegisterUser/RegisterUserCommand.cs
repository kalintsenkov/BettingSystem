namespace BettingSystem.Application.Features.Identity.Commands.RegisterUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Factories.Gamblers;
    using Gamblers;
    using MediatR;

    public class RegisterUserCommand : UserRequestModel, IRequest<Result>
    {
        public string Name { get; }

        public string ConfirmPassword { get; }

        public RegisterUserCommand(
            string name,
            string email,
            string password,
            string confirmPassword)
            : base(email, password)
        {
            this.Name = name;
            this.ConfirmPassword = confirmPassword;
        }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IGamblerFactory gamblerFactory;
            private readonly IGamblerRepository gamblerRepository;

            public RegisterUserCommandHandler(
                IIdentity identity,
                IGamblerFactory gamblerFactory,
                IGamblerRepository gamblerRepository)
            {
                this.identity = identity;
                this.gamblerFactory = gamblerFactory;
                this.gamblerRepository = gamblerRepository;
            }

            public async Task<Result> Handle(
                RegisterUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var gambler = this.gamblerFactory.Build(request.Name);

                user.BecomeGambler(gambler);

                await this.gamblerRepository.Save(gambler, cancellationToken);

                return result;
            }
        }
    }
}
