namespace BettingSystem.Domain.Common.Events.Teams
{
    public class TeamLogoUpdatedEvent : IDomainEvent
    {
        public TeamLogoUpdatedEvent(
            int id,
            byte[] logoOriginalContent,
            byte[] logoThumbnailContent)
        {
            this.Id = id;
            this.LogoOriginalContent = logoOriginalContent;
            this.LogoThumbnailContent = logoThumbnailContent;
        }

        public int Id { get; }

        public byte[] LogoOriginalContent { get; }

        public byte[] LogoThumbnailContent { get; }
    }
}
