namespace BettingSystem.Application.Competitions.Teams.Consumers;

using System.Threading.Tasks;
using Domain.Common.Events.Matches;
using Domain.Competitions.Repositories;
using MassTransit;

public class MatchFinishedEventConsumer : IConsumer<MatchFinishedEvent>
{
    private readonly ITeamDomainRepository teamRepository;

    public MatchFinishedEventConsumer(ITeamDomainRepository teamRepository)
        => this.teamRepository = teamRepository;

    public async Task Consume(ConsumeContext<MatchFinishedEvent> context)
    {
        var message = context.Message;

        var homeScore = message.HomeScore;
        var awayScore = message.AwayScore;

        var homeTeam = await this.teamRepository.Find(message.HomeTeamId);
        var awayTeam = await this.teamRepository.Find(message.AwayTeamId);

        if (homeScore > awayScore)
        {
            homeTeam!.GivePointsForWin();
        }
        else if (homeScore < awayScore)
        {
            awayTeam!.GivePointsForWin();
        }
        else if (homeScore == awayScore)
        {
            homeTeam!.GivePointForDraw();
            awayTeam!.GivePointForDraw();
        }

        await this.teamRepository.Save(homeTeam!);
        await this.teamRepository.Save(awayTeam!);
    }
}