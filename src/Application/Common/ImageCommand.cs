namespace BettingSystem.Application.Common
{
    using System.IO;

    public class ImageCommand
    {
        internal ImageCommand(Stream content) => this.Content = content;

        public Stream Content { get; }
    }
}
