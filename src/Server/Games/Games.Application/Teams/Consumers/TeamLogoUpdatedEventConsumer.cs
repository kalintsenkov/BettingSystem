namespace BettingSystem.Application.Games.Teams.Consumers
{
    using System.Threading.Tasks;
    using Domain.Common.Events.Teams;
    using Domain.Games.Repositories;
    using MassTransit;

    public class TeamLogoUpdatedEventConsumer : IConsumer<TeamLogoUpdatedEvent>
    {
        private readonly ITeamDomainRepository teamRepository;

        public TeamLogoUpdatedEventConsumer(ITeamDomainRepository teamRepository)
            => this.teamRepository = teamRepository;

        public async Task Consume(ConsumeContext<TeamLogoUpdatedEvent> context)
        {
            var eventMessage = context.Message;

            var team = await this.teamRepository.Find(eventMessage.Id);

            team.UpdateLogo(
                eventMessage.LogoOriginalContent,
                eventMessage.LogoThumbnailContent);

            await this.teamRepository.Save(team);
        }
    }
}
