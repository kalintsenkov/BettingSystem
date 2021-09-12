namespace BettingSystem.Domain.Common.Models.Images
{
    public class Image : ValueObject
    {
        internal Image(byte[] original, byte[] thumbnail)
        {
            this.Original = original;
            this.Thumbnail = thumbnail;
        }

        public byte[] Original { get; }

        public byte[] Thumbnail { get; }
    }
}
