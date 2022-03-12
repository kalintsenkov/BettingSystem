namespace BettingSystem.Domain.Common.Events.Matches;

using System;

public class MatchCreatedEvent : IDomainEvent
{
    public MatchCreatedEvent(DateTime startDate) 
        => this.StartDate = startDate;

    public DateTime StartDate { get; }
}