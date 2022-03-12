namespace BettingSystem.Domain.Common.Models;

public class Image : Entity<int>
{
    internal Image(
        byte[] originalContent, 
        byte[] thumbnailContent)
    {
        this.OriginalContent = originalContent;
        this.ThumbnailContent = thumbnailContent;
    }

    public byte[] OriginalContent { get; }

    public byte[] ThumbnailContent { get; }
}