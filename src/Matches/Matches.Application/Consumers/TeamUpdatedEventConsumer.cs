namespace BettingSystem.Application.Matches.Consumers
{
    using System.Threading.Tasks;
    using Domain.Common.Events.Teams;
    using Domain.Matches.Repositories;
    using MassTransit;

    public class TeamUpdatedEventConsumer : IConsumer<TeamUpdatedEvent>
    {
        private readonly IMatchDomainRepository matchRepository;

        public TeamUpdatedEventConsumer(IMatchDomainRepository matchRepository)
            => this.matchRepository = matchRepository;

        public async Task Consume(ConsumeContext<TeamUpdatedEvent> context)
        {
            var eventMessage = context.Message;

            var team = await this.matchRepository.GetTeam(eventMessage.Id);

            team.UpdateName(eventMessage.Name);

            await this.matchRepository.SaveTeam(team);
        }
    }
}
