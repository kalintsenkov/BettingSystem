namespace BettingSystem.Domain.Common.Events.Teams
{
    public class TeamUpdatedEvent : IDomainEvent
    {
        public TeamUpdatedEvent(int teamId, string teamName)
        {
            this.TeamId = teamId;
            this.TeamName = teamName;
        }

        public int TeamId { get; }

        public string TeamName { get; }
    }
}
