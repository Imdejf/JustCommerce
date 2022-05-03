using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.Interfaces
{
    public interface IFtpFileManager
    {
        Task RemoveAllProductImage(Guid productId, CancellationToken cancellationToken = default);
        Task<string> SaveProductPhotoOnFtpAsync(Base64File file,Guid productId, string fileName, CancellationToken cancellationToken = default);
        Task RemoveFileFromFtpAsync(string ftpFilePath, CancellationToken cancellationToken = default);
    }
}
