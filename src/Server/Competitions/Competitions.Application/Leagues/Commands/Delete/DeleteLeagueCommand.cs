namespace BettingSystem.Application.Competitions.Leagues.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Domain.Competitions.Repositories;
using MediatR;

public class DeleteLeagueCommand : EntityCommand<int>, IRequest<Result>
{
    public class DeleteLeagueCommandHandler : IRequestHandler<DeleteLeagueCommand, Result>
    {
        private readonly ILeagueDomainRepository leagueRepository;

        public DeleteLeagueCommandHandler(ILeagueDomainRepository leagueRepository)
            => this.leagueRepository = leagueRepository;

        public async Task<Result> Handle(
            DeleteLeagueCommand request,
            CancellationToken cancellationToken)
            => await this.leagueRepository.Delete(
                request.Id,
                cancellationToken);
    }
}