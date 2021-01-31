namespace BettingSystem.Infrastructure.Common.Persistence.Models
{
    using Application.Common.Mapping;
    using Domain.Matches.Models;

    internal class ImageData : IMapFrom<Image>, IMapTo<Image>
    {
        public byte[] OriginalContent { get; set; } = default!;

        public byte[] ThumbnailContent { get; set; } = default!;
    }
}
