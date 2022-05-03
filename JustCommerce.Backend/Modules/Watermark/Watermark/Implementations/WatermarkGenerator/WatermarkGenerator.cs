using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Watermark.Enums;
using Watermark.Implementations.Tools;
using Watermark.Interfaces.WatermarkGenerator;

namespace Watermark.Implementations.WatermarkGenerator
{
    /// <summary>
    /// Default implementation class of <see cref="IWatermarkGenerator"/> and <see cref="IWatermarkSetResponse"/>
    /// </summary>
    public sealed class WatermarkGenerator : 
        IWatermarkGenerator,
        IWatermarkSetResponse
    {                
        private byte[]? _currentFile;
        private readonly IServiceProvider _services;


        /// <summary>
        /// Constructor used by DI container
        /// </summary>
        /// <param name="services">source</param>
        public WatermarkGenerator(IServiceProvider services)
        {            
            _services = services;
        }

        /// <summary>
        /// Return file as base64 format
        /// </summary>
        /// <returns>string</returns>
        public string AsBase64File()
        {
            var type = WatermarkHelper.GetTypeOfFile(_currentFile);
            var handler = getHandler(type);

            var result = handler.SetWatermark(_currentFile);
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// Return file as byte array format
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] AsByteArray()
        {
            var type = WatermarkHelper.GetTypeOfFile(_currentFile);
            var handler = getHandler(type);
            
            return handler.SetWatermark(_currentFile);
        }

        /// <summary>
        /// Return file as stream format
        /// </summary>
        /// <returns>stream</returns>
        public Stream AsStream()
        {
            var type = WatermarkHelper.GetTypeOfFile(_currentFile);
            var handler = getHandler(type);

            var result = handler.SetWatermark(_currentFile);
            return new MemoryStream(result);
        }

        /// <summary>
        /// Asynchronous method
        /// Return file as stream format 
        /// </summary>
        /// <returns>MemoryStream</returns>
        public async Task<Stream> AsStreamAsync(CancellationToken cancellationToken = default)
        {

            var type = WatermarkHelper.GetTypeOfFile(_currentFile);
            var handler = getHandler(type);

            var result = await handler.SetWatermarkAsync(_currentFile, cancellationToken);
            return new MemoryStream(result);
        }

        /// <summary>
        /// Asynchronous method
        /// Return file as byte array format 
        /// </summary>
        /// <returns>byte[]</returns>
        public Task<byte[]> AsByteArrayAsync(CancellationToken cancellationToken = default)
        {
            var type = WatermarkHelper.GetTypeOfFile(_currentFile);
            var handler = getHandler(type);

            return handler.SetWatermarkAsync(_currentFile, cancellationToken);
        }

        /// <summary>
        /// Asynchronous method
        /// Return file as string format 
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> AsBase64FileAsync(CancellationToken cancellationToken = default)
        {
            var type = WatermarkHelper.GetTypeOfFile(_currentFile);
            var handler = getHandler(type);

            var result = await handler.SetWatermarkAsync(_currentFile, cancellationToken);
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// Add array value to _currentFile
        /// </summary>
        /// <param name="array"></param>
        /// <returns>IWatermarkSetResponse</returns>
        public IWatermarkSetResponse OnFile(byte[] array)
        {
            _currentFile = array;            
            return this;
        }

        /// <summary>
        /// Convert stream to array and add value to _currentFile
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>IWatermarkSetResponse</returns>
        public IWatermarkSetResponse OnFile(MemoryStream stream)
        {
            _currentFile = stream.ToArray();
            return this;
        }

        /// <summary>
        /// Convert string to array and add value to _currentFile
        /// </summary>
        /// <param name="base64File"></param>
        /// <returns>IWatermarkSetResponse</returns>
        public IWatermarkSetResponse OnFile(string base64File)
        {
            _currentFile = Convert.FromBase64String(base64File);
            return this;
        }
       
        private IWatermarkHandler getHandler(WatermarkFileType fileType) 
        {
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(c => c.GetInterfaces()
                .Any(c => c == typeof(IWatermarkHandler)))
                .ToList();

            foreach (var type in types)
            {                
                 var serviceObj = _services.GetServices(typeof(IWatermarkHandler))
                    .Where(c => c.GetType() == type)
                    .FirstOrDefault();

                var service = (IWatermarkHandler)serviceObj;
                if (service.Type == fileType)
                {
                    return service;
                }
            }

            throw new NotImplementedException();
        }        
    }
}
