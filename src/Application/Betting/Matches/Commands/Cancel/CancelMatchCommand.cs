namespace BettingSystem.Application.Betting.Matches.Commands.Cancel
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Domain.Betting.Repositories;
    using MediatR;

    public class CancelMatchCommand : EntityCommand<int>, IRequest<Result>
    {
        public class CancelMatchCommandHandler : IRequestHandler<CancelMatchCommand, Result>
        {
            private readonly IMatchDomainRepository matchRepository;

            public CancelMatchCommandHandler(IMatchDomainRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                CancelMatchCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.Id);
                }

                match.Cancel();

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
