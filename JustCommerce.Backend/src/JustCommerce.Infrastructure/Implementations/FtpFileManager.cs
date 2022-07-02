using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Models;

namespace JustCommerce.Infrastructure.Implementations
{
    internal sealed class FtpFileManager : IFtpFileManager
    {
        private const string FOLDER_NAME = "AccountFiles";
        private readonly DataSharp.FtpFileManagement.Interfaces.IFtpFileManager _ftpFileManager;

        public FtpFileManager(DataSharp.FtpFileManagement.Interfaces.IFtpFileManager ftpFileManager)
        {
            _ftpFileManager = ftpFileManager;
        }

        public async Task<byte[]> GetIconFile(string filePath, CancellationToken cancellationToken)
        {
            var connection = _ftpFileManager.GetCurrentConnection().Value;
            var file = await _ftpFileManager.GetAsByteArrayAsync(filePath);

            return file;
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

        public async Task<string> SaveProductIconOnFtpAsync(Base64File file, Guid productId, string fileName, string productColor, CancellationToken cancellationToken = default)
        {
            var connection = _ftpFileManager.GetCurrentConnection().Value;
            if (!await _ftpFileManager.DirectoryExistsAsync($"Icon-Product/{productId}-icon"))
            {
                await _ftpFileManager.CreateDirectoryAsync($"Icon-Product/{productId}-icon");
            }
            var ftpFilePath = @$"{connection.HttpUri}{connection.RootFolder}/{productId}-icon/{fileName}_{productColor}{file.FileExtension}";
            await _ftpFileManager.CreateAsync(ftpFilePath, file.ByteArray);
            return ftpFilePath;
        }

        public async Task<string> SaveProductPhotoOnFtpAsync(Base64File file, Guid productId, string fileName, CancellationToken cancellationToken = default)
        {
            var connection = _ftpFileManager.GetCurrentConnection().Value;
            if (!await _ftpFileManager.DirectoryExistsAsync($"Product/{productId}"))
            {
                await _ftpFileManager.CreateDirectoryAsync($"Product/{productId}");
            }
            var ftpFilePath = @$"{connection.HttpUri}{connection.RootFolder}/{productId}/{fileName}{file.FileExtension}";
            await _ftpFileManager.CreateAsync(ftpFilePath, file.ByteArray);
            return ftpFilePath;
        }

        public async Task<string> SaveUserPicturePhotoOnFtpAsync(Base64File file, CancellationToken cancellationToken = default)
        {
            var currentConenction = _ftpFileManager.GetCurrentConnection();
            string ftpFilePath = string.Empty;
            do
            {
                ftpFilePath = $@"{currentConenction.Value.HttpsUri}{currentConenction.Value.RootFolder}AccountFiles/{Guid.NewGuid()}{file.FileExtension}";
            }
            while (await _ftpFileManager.ExistsAsync(ftpFilePath));

            await _ftpFileManager.CreateAsync(ftpFilePath, file.ByteArray);
            ftpFilePath = ftpFilePath.Replace(FOLDER_NAME, $"justcommerce/{FOLDER_NAME}");
            return ftpFilePath;
        }
    }
}
