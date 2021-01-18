namespace BettingSystem.Application.Competitions.Matches.Commands.SecondHalf
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Domain.Competitions.Repositories;
    using MediatR;

    public class StartMatchSecondHalfCommand : EntityCommand<int>, IRequest<Result>
    {
        public class StartMatchSecondHalfCommandHandler : IRequestHandler<StartMatchSecondHalfCommand, Result>
        {
            private readonly IMatchDomainRepository matchRepository;

            public StartMatchSecondHalfCommandHandler(IMatchDomainRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                StartMatchSecondHalfCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.Id);
                }

                match.StartSecondHalf();

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
