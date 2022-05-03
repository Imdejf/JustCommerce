using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.Interfaces
{
    public interface IFtpFileManager
    {
        Task<string> SaveProductPhotoOnFtpAsync(Base64File file,Guid productId, CancellationToken cancellationToken = default);
        Task RemoveFileFromFtpAsync(string ftpFilePath, CancellationToken cancellationToken = default);
    }
}
