namespace BettingSystem.Application.Games.Teams.Consumers
{
    using System.Threading.Tasks;
    using Domain.Common.Events.Teams;
    using Domain.Games.Factories.Teams;
    using Domain.Games.Repositories;
    using MassTransit;

    public class TeamCreatedEventConsumer : IConsumer<TeamCreatedEvent>
    {
        private readonly ITeamFactory teamFactory;
        private readonly ITeamDomainRepository teamRepository;

        public TeamCreatedEventConsumer(
            ITeamFactory teamFactory,
            ITeamDomainRepository teamRepository)
        {
            this.teamFactory = teamFactory;
            this.teamRepository = teamRepository;
        }

        public async Task Consume(ConsumeContext<TeamCreatedEvent> context)
        {
            var message = context.Message;

            var team = this.teamFactory
                .WithName(message.Name)
                .WithImage(
                    message.ImageOriginal,
                    message.ImageThumbnail)
                .Build();

            await this.teamRepository.Save(team);
        }
    }
}
