namespace BettingSystem.Application.Betting.Matches.Commands.FirstHalf
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Domain.Betting.Repositories;
    using MediatR;

    public class StartMatchFirstHalfCommand : EntityCommand<int>, IRequest<Result>
    {
        public class StartMatchFirstHalfCommandHandler : IRequestHandler<StartMatchFirstHalfCommand, Result>
        {
            private readonly IMatchDomainRepository matchRepository;

            public StartMatchFirstHalfCommandHandler(IMatchDomainRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                StartMatchFirstHalfCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.Id);
                }

                match.StartFirstHalf();

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
