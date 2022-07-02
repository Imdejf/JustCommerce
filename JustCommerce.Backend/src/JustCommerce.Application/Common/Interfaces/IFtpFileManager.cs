using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.Interfaces
{
    public interface IFtpFileManager
    {
        Task RemoveAllProductImage(Guid productId, CancellationToken cancellationToken = default);
        Task<string> SaveProductIconOnFtpAsync(Base64File file, Guid productId, string fileName,string productColor, CancellationToken cancellationToken = default);
        Task<string> SaveProductPhotoOnFtpAsync(Base64File file,Guid productId, string fileName, CancellationToken cancellationToken = default);
        Task RemoveFileFromFtpAsync(string ftpFilePath, CancellationToken cancellationToken = default);
        Task<string> SaveUserPicturePhotoOnFtpAsync(Base64File file, CancellationToken cancellationToken = default);
    }
}
