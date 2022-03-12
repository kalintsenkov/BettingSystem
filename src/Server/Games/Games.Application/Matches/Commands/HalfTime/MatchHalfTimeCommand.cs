namespace BettingSystem.Application.Games.Matches.Commands.HalfTime;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Exceptions;
using Domain.Games.Repositories;
using MediatR;

public class MatchHalfTimeCommand : EntityCommand<int>, IRequest<Result>
{
    public class MatchHalfTimeCommandHandler : IRequestHandler<MatchHalfTimeCommand, Result>
    {
        private readonly IMatchDomainRepository matchRepository;

        public MatchHalfTimeCommandHandler(IMatchDomainRepository matchRepository)
            => this.matchRepository = matchRepository;

        public async Task<Result> Handle(
            MatchHalfTimeCommand request,
            CancellationToken cancellationToken)
        {
            var match = await this.matchRepository.Find(
                request.Id,
                cancellationToken);

            if (match == null)
            {
                throw new NotFoundException(nameof(match), request.Id);
            }

            match.HalfTime();

            await this.matchRepository.Save(match, cancellationToken);

            return Result.Success;
        }
    }
}