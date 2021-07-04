namespace BettingSystem.Application.Games.Teams.Consumers
{
    using System.Threading.Tasks;
    using Domain.Common.Events.Teams;
    using Domain.Games.Repositories;
    using MassTransit;

    public class TeamUpdatedEventConsumer : IConsumer<TeamUpdatedEvent>
    {
        private readonly ITeamDomainRepository teamRepository;

        public TeamUpdatedEventConsumer(ITeamDomainRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task Consume(ConsumeContext<TeamUpdatedEvent> context)
        {
            var eventMessage = context.Message;

            var team = await this.teamRepository.Find(eventMessage.Id);

            team.UpdateName(eventMessage.Name);

            await this.teamRepository.Save(team);
        }
    }
}
