namespace BettingSystem.Domain.Common.Events.Teams
{
    public class TeamCreatedEvent : IDomainEvent
    {
        public TeamCreatedEvent(string name) => this.Name = name;

        public string Name { get; }
    }
}
