namespace BettingSystem.Application.Betting.Matches.Commands.SecondHalf
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Domain.Betting.Repositories;
    using MediatR;

    public class MatchSecondHalfCommand : EntityCommand<int>, IRequest<Result>
    {
        public class MatchSecondHalfCommandHandler : IRequestHandler<MatchSecondHalfCommand, Result>
        {
            private readonly IMatchDomainRepository matchRepository;

            public MatchSecondHalfCommandHandler(IMatchDomainRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                MatchSecondHalfCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.Id);
                }

                match.SecondHalf();

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
