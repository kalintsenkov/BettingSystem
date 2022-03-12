namespace BettingSystem.Domain.Common.Events.Matches;

public class MatchStatisticsUpdatedEvent : IDomainEvent
{
    public MatchStatisticsUpdatedEvent(
        int id,
        int? homeScore,
        int? awayScore,
        int? halfTimeHomeScore,
        int? halfTimeAwayScore)
    {
        this.Id = id;
        this.HomeScore = homeScore;
        this.AwayScore = awayScore;
        this.HalfTimeHomeScore = halfTimeHomeScore;
        this.HalfTimeAwayScore = halfTimeAwayScore;
    }

    public int Id { get; }

    public int? HomeScore { get; }

    public int? AwayScore { get; }

    public int? HalfTimeHomeScore { get; }

    public int? HalfTimeAwayScore { get; }
}