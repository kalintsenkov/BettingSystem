namespace BettingSystem.Domain.Common.Models.Images
{
    public class Image : ValueObject
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
}
