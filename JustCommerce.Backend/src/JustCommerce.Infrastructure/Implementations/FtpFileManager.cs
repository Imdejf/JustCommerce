using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Models;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class FtpFileManager : IFtpFileManager
    {
        private readonly DataSharp.FtpFileManagement.Interfaces.IFtpFileManager _FtpFileManager;

        public FtpFileManager(DataSharp.FtpFileManagement.Interfaces.IFtpFileManager ftpFileManager)
        {
            _FtpFileManager = ftpFileManager;
        }
        public async Task RemoveFileFromFtpAsync(string ftpFilePath, CancellationToken cancellationToken = default)
        {
            if (!await _FtpFileManager.ExistsAsync(ftpFilePath))
            {
                throw new EntityNotFoundException($"File with {ftpFilePath} path not exist", 0);
            }
            await _FtpFileManager.RemoveAsync(ftpFilePath);
        }

        public async Task<string> SavePostPhotoOnFtpAsync(Base64File file, CancellationToken cancellationToken = default)
        {
            var filePath = Guid.NewGuid().ToString();
            var connection = _FtpFileManager.GetCurrentConnection();
            var ftpFilePath = @$"{connection.Value.HttpUri}{connection.Value.RootFolder}/{filePath}{file.FileExtension}";
            await _FtpFileManager.CreateAsync(ftpFilePath, file.ByteArray);
            return ftpFilePath;
        }
    }
}
