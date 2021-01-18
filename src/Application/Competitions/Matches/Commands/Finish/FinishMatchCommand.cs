namespace BettingSystem.Application.Competitions.Matches.Commands.Finish
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Exceptions;
    using Domain.Competitions.Repositories;
    using MediatR;

    public class FinishMatchCommand : EntityCommand<int>, IRequest<Result>
    {
        public class FinishMatchCommandHandler : IRequestHandler<FinishMatchCommand, Result>
        {
            private readonly IMatchDomainRepository matchRepository;

            public FinishMatchCommandHandler(IMatchDomainRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                FinishMatchCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.Id);
                }

                match.Finish();

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
