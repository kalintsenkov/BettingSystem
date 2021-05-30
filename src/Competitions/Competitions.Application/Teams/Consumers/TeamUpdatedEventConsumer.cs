namespace BettingSystem.Application.Competitions.Teams.Consumers
{
    using System.Threading.Tasks;
    using Domain.Common.Events.Teams;
    using Domain.Competitions.Repositories;
    using MassTransit;

    public class TeamUpdatedEventConsumer : IConsumer<TeamUpdatedEvent>
    {
        private readonly ITeamDomainRepository teamRepository;

        public TeamUpdatedEventConsumer(ITeamDomainRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task Consume(ConsumeContext<TeamUpdatedEvent> context)
        {
            var eventMessage = context.Message;

            var team = await this.teamRepository.Find(eventMessage.TeamId);

            team.UpdateName(eventMessage.TeamName);

            await this.teamRepository.Save(team);
        }
    }
}
