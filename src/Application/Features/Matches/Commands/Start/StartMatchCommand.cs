namespace BettingSystem.Application.Features.Matches.Commands.Start
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Exceptions;
    using MediatR;

    public class StartMatchCommand : EntityCommand<int>, IRequest<Result>
    {
        public class StartMatchCommandHandler : IRequestHandler<StartMatchCommand, Result>
        {
            private readonly IMatchRepository matchRepository;

            public StartMatchCommandHandler(IMatchRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                StartMatchCommand request,
                CancellationToken cancellationToken)
            {
                var match = await this.matchRepository.Find(
                    request.Id,
                    cancellationToken);

                if (match == null)
                {
                    throw new NotFoundException(nameof(match), request.Id);
                }

                match.Start();

                await this.matchRepository.Save(match, cancellationToken);

                return Result.Success;
            }
        }
    }
}
