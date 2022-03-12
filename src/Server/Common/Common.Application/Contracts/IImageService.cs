namespace BettingSystem.Application.Common.Contracts;

using System.Threading.Tasks;
using Images;

public interface IImageService
{
    Task<ImageResponseModel> Process(ImageRequestModel image);
}