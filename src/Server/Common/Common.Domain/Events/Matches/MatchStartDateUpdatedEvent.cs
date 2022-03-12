namespace BettingSystem.Domain.Common.Events.Matches;

using System;

public class MatchStartDateUpdatedEvent : IDomainEvent
{
    public MatchStartDateUpdatedEvent(int id, DateTime startDate)
    {
        this.Id = id;
        this.StartDate = startDate;
    }

    public int Id { get; }

    public DateTime StartDate { get; }
}