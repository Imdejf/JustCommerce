using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.Interfaces
{
    public interface IWatermarkManager
    {
        Task<Base64File> AddWatermarkToPicture(Base64File base64Picture, CancellationToken cancellationToken = default);
    }
}
