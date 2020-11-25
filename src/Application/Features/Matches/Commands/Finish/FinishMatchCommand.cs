namespace BettingSystem.Application.Features.Matches.Commands.Finish
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Exceptions;
    using MediatR;

    public class FinishMatchCommand : EntityCommand<int>, IRequest<Result>
    {
        public class FinishMatchCommandHandler : IRequestHandler<FinishMatchCommand, Result>
        {
            private readonly IMatchRepository matchRepository;

            public FinishMatchCommandHandler(IMatchRepository matchRepository)
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
