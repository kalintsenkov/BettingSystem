namespace BettingSystem.Application.Identity.Commands.ChangePassword;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Contracts;
using MediatR;

public class ChangePasswordCommand : IRequest<Result>
{
    public string CurrentPassword { get; set; } = default!;

    public string NewPassword { get; set; } = default!;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
    {
        private readonly IIdentity identity;
        private readonly ICurrentUser currentUser;

        public ChangePasswordCommandHandler(
            IIdentity identity,
            ICurrentUser currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(
            ChangePasswordCommand request,
            CancellationToken cancellationToken)
            => await this.identity.ChangePassword(new ChangePasswordRequestModel(
                this.currentUser.UserId,
                request.CurrentPassword,
                request.NewPassword));
    }
}