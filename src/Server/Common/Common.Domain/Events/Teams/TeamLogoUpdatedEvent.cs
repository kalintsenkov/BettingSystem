namespace BettingSystem.Domain.Common.Events.Teams;

public class TeamLogoUpdatedEvent : IDomainEvent
{
    public TeamLogoUpdatedEvent(
        int id,
        string name,
        byte[] logoOriginalContent,
        byte[] logoThumbnailContent)
    {
        this.Id = id;
        this.Name = name;
        this.LogoOriginalContent = logoOriginalContent;
        this.LogoThumbnailContent = logoThumbnailContent;
    }

    public int Id { get; }

    public string Name { get; }

    public byte[] LogoOriginalContent { get; }

    public byte[] LogoThumbnailContent { get; }
}