namespace BettingSystem.Application.Features.Matches.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using MediatR;

    public class DeleteMatchCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand, Result>
        {
            private readonly IMatchRepository matchRepository;

            public DeleteMatchCommandHandler(IMatchRepository matchRepository)
                => this.matchRepository = matchRepository;

            public async Task<Result> Handle(
                DeleteMatchCommand request,
                CancellationToken cancellationToken)
                => await this.matchRepository.Delete(
                    request.Id,
                    cancellationToken);
        }
    }
}
