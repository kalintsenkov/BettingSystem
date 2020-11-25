namespace BettingSystem.Application.Features.Gamblers.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Contracts;
    using MediatR;

    public class EditGamblerCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public class EditGamblerCommandHandler : IRequestHandler<EditGamblerCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IGamblerRepository gamblerRepository;

            public EditGamblerCommandHandler(
                ICurrentUser currentUser,
                IGamblerRepository gamblerRepository)
            {
                this.currentUser = currentUser;
                this.gamblerRepository = gamblerRepository;
            }

            public async Task<Result> Handle(
                EditGamblerCommand request,
                CancellationToken cancellationToken)
            {
                var gambler = await this.gamblerRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                if (request.Id != gambler.Id)
                {
                    return "You cannot edit this profile.";
                }

                gambler.UpdateName(request.Name);

                await this.gamblerRepository.Save(gambler, cancellationToken);

                return Result.Success;
            }
        }
    }
}
