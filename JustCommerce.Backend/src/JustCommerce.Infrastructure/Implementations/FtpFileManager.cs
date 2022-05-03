using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Models;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class FtpFileManager : IFtpFileManager
    {
        private readonly DataSharp.FtpFileManagement.Interfaces.IFtpFileManager _ftpFileManager;

        public FtpFileManager(DataSharp.FtpFileManagement.Interfaces.IFtpFileManager ftpFileManager)
        {
            _ftpFileManager = ftpFileManager;
        }

       public async Task RemoveAllProductImage(Guid productId, CancellationToken cancellationToken = default)
        {
            var connection = _ftpFileManager.GetCurrentConnection().Value;
            var ftpFilePath = @$"{connection.HttpUri}{connection.RootFolder}/{productId}";
            await _ftpFileManager.RemoveAllAsync(ftpFilePath);
        }

        public async Task RemoveFileFromFtpAsync(string ftpFilePath, CancellationToken cancellationToken = default)
        {
            if (!await _ftpFileManager.ExistsAsync(ftpFilePath))
            {
                throw new EntityNotFoundException($"File with {ftpFilePath} path not exist", 0);
            }
            await _ftpFileManager.RemoveAsync(ftpFilePath);
        }

        public async Task<string> SaveProductPhotoOnFtpAsync(Base64File file, Guid productId, string fileName, CancellationToken cancellationToken = default)
        {
            var connection = _ftpFileManager.GetCurrentConnection().Value;
            if (!await _ftpFileManager.DirectoryExistsAsync($"/{productId}"))
            {
                await _ftpFileManager.CreateDirectoryAsync($"/{productId}");
            }
            var ftpFilePath = @$"{connection.HttpUri}{connection.RootFolder}/{productId}/{fileName}{file.FileExtension}";
            await _ftpFileManager.CreateAsync(ftpFilePath, file.ByteArray);
            return ftpFilePath;
        }
    }
}
