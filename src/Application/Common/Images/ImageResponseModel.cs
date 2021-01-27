namespace BettingSystem.Application.Common.Images
{
    public class ImageResponseModel
    {
        public ImageResponseModel(byte[] original, byte[] thumbnail)
        {
            this.Original = original;
            this.Thumbnail = thumbnail;
        }

        public byte[] Original { get; }

        public byte[] Thumbnail { get; }
    }
}
