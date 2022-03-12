namespace BettingSystem.Application.Competitions.Teams.Consumers;

using System.Threading.Tasks;
using Domain.Common.Events.Teams;
using Domain.Competitions.Factories.Teams;
using Domain.Competitions.Repositories;
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
        var team = this.teamFactory.Build(context.Message.Name);

        await this.teamRepository.Save(team);
    }
}