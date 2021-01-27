namespace BettingSystem.Application.Common.Images
{
    using System.IO;

    public class ImageRequestModel
    {
        internal ImageRequestModel(Stream content) => this.Content = content;

        public Stream Content { get; }
    }
}
