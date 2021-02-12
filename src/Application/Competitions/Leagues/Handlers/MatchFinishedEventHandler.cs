namespace BettingSystem.Application.Competitions.Leagues.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Competitions.Repositories;
    using Domain.Matches.Events;

    public class MatchFinishedEventHandler : IEventHandler<MatchFinishedEvent>
    {
        private readonly ILeagueDomainRepository leagueRepository;

        public MatchFinishedEventHandler(ILeagueDomainRepository leagueRepository)
            => this.leagueRepository = leagueRepository;

        public Task Handle(MatchFinishedEvent domainEvent)
            => this.leagueRepository.GiveTeamPoints(
                domainEvent.HomeTeamId,
                domainEvent.AwayTeamId,
                domainEvent.HomeScore,
                domainEvent.AwayScore);
    }
}
