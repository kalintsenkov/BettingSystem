namespace BettingSystem.Domain.Common.Events.Teams
{
    public class TeamCreatedEvent : IDomainEvent
    {
        public TeamCreatedEvent(
            string name, 
            byte[] imageOriginal, 
            byte[] imageThumbnail)
        {
            this.Name = name;
            this.ImageOriginal = imageOriginal;
            this.ImageThumbnail = imageThumbnail;
        }

        public string Name { get; }

        public byte[] ImageOriginal { get; }

        public byte[] ImageThumbnail { get; }
    }
}
