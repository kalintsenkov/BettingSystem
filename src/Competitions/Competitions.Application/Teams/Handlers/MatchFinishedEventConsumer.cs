namespace BettingSystem.Application.Competitions.Teams.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Common.Events.Matches;
    using Domain.Competitions.Repositories;
    using MassTransit;

    public class MatchFinishedEventConsumer : IEventConsumer<MatchFinishedEvent>
    {
        private readonly ITeamDomainRepository teamRepository;

        public MatchFinishedEventConsumer(ITeamDomainRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task Consume(ConsumeContext<MatchFinishedEvent> context)
            => await this.teamRepository.GiveTeamPoints(
                context.Message.HomeTeamId,
                context.Message.AwayTeamId,
                context.Message.HomeScore,
                context.Message.AwayScore);
    }
}
