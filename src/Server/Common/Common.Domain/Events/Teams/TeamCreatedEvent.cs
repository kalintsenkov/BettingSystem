namespace BettingSystem.Domain.Common.Events.Teams;

public class TeamCreatedEvent : IDomainEvent
{
    public TeamCreatedEvent(
        string name, 
        byte[] logoOriginalContent, 
        byte[] logoThumbnailContent)
    {
        this.Name = name;
        this.LogoOriginalContent = logoOriginalContent;
        this.LogoThumbnailContent = logoThumbnailContent;
    }

    public string Name { get; }

    public byte[] LogoOriginalContent { get; }

    public byte[] LogoThumbnailContent { get; }
}