namespace BettingSystem.Application.Competitions.Leagues.Commands.AddTeam;

using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Exceptions;
using Domain.Competitions.Repositories;
using MediatR;

public class AddTeamCommand : EntityCommand<int>, IRequest<Result>
{
    public int TeamId { get; set; }

    public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, Result>
    {
        private readonly ITeamDomainRepository teamRepository;
        private readonly ILeagueDomainRepository leagueRepository;

        public AddTeamCommandHandler(
            ITeamDomainRepository teamRepository,
            ILeagueDomainRepository leagueRepository)
        {
            this.teamRepository = teamRepository;
            this.leagueRepository = leagueRepository;
        }

        public async Task<Result> Handle(
            AddTeamCommand request,
            CancellationToken cancellationToken)
        {
            var league = await this.leagueRepository.Find(
                request.Id,
                cancellationToken);

            if (league == null)
            {
                throw new NotFoundException(nameof(league), request.Id);
            }

            var team = await this.teamRepository.Find(
                request.TeamId,
                cancellationToken);

            if (team == null)
            {
                throw new NotFoundException(nameof(team), request.TeamId);
            }

            league.AddTeam(team);

            await this.leagueRepository.Save(league, cancellationToken);

            return Result.Success;
        }
    }
}