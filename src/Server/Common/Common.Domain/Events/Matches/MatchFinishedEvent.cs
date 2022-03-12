namespace BettingSystem.Domain.Common.Events.Matches;

public class MatchFinishedEvent : IDomainEvent
{
    public MatchFinishedEvent(
        int homeTeamId,
        int awayTeamId,
        int homeScore,
        int awayScore)
    {
        this.HomeTeamId = homeTeamId;
        this.AwayTeamId = awayTeamId;
        this.HomeScore = homeScore;
        this.AwayScore = awayScore;
    }

    public int HomeTeamId { get; }

    public int AwayTeamId { get; }

    public int HomeScore { get; }

    public int AwayScore { get; }
}