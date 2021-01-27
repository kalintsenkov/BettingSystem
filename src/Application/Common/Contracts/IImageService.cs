namespace BettingSystem.Application.Common.Contracts
{
    using System.Threading.Tasks;

    public interface IImageService
    {
        Task<(byte[] Original, byte[] Thumbnail)> Process(ImageCommand image);
    }
}
