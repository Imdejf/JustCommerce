using JustCommerce.Shared.Models;

namespace JustCommerce.Application.Common.Interfaces
{
    public interface IFtpFileManager
    {
        Task<string> SavePostPhotoOnFtpAsync(Base64File file, CancellationToken cancellationToken = default);
        Task RemoveFileFromFtpAsync(string ftpFilePath, CancellationToken cancellationToken = default);
    }
}
