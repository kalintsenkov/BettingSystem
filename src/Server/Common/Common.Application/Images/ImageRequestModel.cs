namespace BettingSystem.Application.Common.Images;

using System.IO;

public class ImageRequestModel
{
    public ImageRequestModel(Stream content) => this.Content = content;

    public Stream Content { get; }
}