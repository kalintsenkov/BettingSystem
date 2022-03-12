namespace BettingSystem.Domain.Common.Events.Teams;

public class TeamNameUpdatedEvent : IDomainEvent
{
    public TeamNameUpdatedEvent(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public int Id { get; }

    public string Name { get; }
}