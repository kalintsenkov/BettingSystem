namespace BettingSystem.Application.Competitions.Teams.Consumers;

using System.Threading.Tasks;
using Domain.Common.Events.Teams;
using Domain.Competitions.Repositories;
using MassTransit;

public class TeamNameUpdatedEventConsumer : IConsumer<TeamNameUpdatedEvent>
{
    private readonly ITeamDomainRepository teamRepository;

    public TeamNameUpdatedEventConsumer(ITeamDomainRepository teamRepository)
        => this.teamRepository = teamRepository;

    public async Task Consume(ConsumeContext<TeamNameUpdatedEvent> context)
    {
        var eventMessage = context.Message;

        var team = await this.teamRepository.Find(eventMessage.Id);

        team!.UpdateName(eventMessage.Name);

        await this.teamRepository.Save(team);
    }
}