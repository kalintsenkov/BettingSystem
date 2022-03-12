namespace BettingSystem.Domain.Common.Events.Matches;

public class MatchStatusUpdatedEvent : IDomainEvent
{
    public MatchStatusUpdatedEvent(int id, int status)
    {
        this.Id = id;
        this.Status = status;
    }

    public int Id { get; }

    public int Status { get; }
}