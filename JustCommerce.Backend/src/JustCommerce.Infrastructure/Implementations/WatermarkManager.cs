using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Models;
using Watermark.Interfaces.WatermarkGenerator;

namespace JustCommerce.Infrastructure.Implementations
{
    public class WatermarkManager : IWatermarkManager
    {
        private readonly IWatermarkGenerator _wrapper;

        public WatermarkManager(IWatermarkGenerator wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<Base64File> AddWatermarkToPicture(Base64File base64Picture, CancellationToken cancellationToken = default)
        {
            var base64 = await _wrapper.OnFile(base64Picture.Base64String)
                                      .AsBase64FileAsync(cancellationToken);

           return new Base64File(base64);
        }
    }
}
