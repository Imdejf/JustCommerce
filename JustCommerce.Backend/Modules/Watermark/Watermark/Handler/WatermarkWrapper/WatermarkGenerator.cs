using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Watermark.Configs.Abstract;
using Watermark.Enums;

namespace Watermark.Handler.WatermarkWrapper
{
    internal abstract class WatermarkGenerator<TConfig>
        where TConfig : CommonConfig
    {
        protected Dictionary<WatermarkOperation, Func<byte[], MemoryStream>> _FuncsMap { get; set; } = new Dictionary<WatermarkOperation, Func<byte[], MemoryStream>>();
        protected TConfig _Config { get; set; }
        protected WatermarkGenerator(TConfig config)
        {
            _Config = config;
        }

        /// <summary>
        /// Main method for adding watermark to .docx file
        /// </summary>
        /// <param name="array">
        /// Throws
        /// <list type="bullet">
        /// <item>
        /// <term><see cref="ArgumentNullException"/></term>
        /// <description>If send null byte[]</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>bytes of file</returns>
        public virtual byte[] SetWatermark(byte[]? array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("bytes of file can't be null");
            }
            var tmp = new MemoryStream();
            foreach (WatermarkOperation flag in Enum.GetValues(_Config.Operation.GetType()).Cast<Enum>().Where(_Config.Operation.HasFlag))
            {
                tmp = _FuncsMap[flag](array);
                array = tmp.ToArray();
            }
            return tmp.ToArray();
        }
        public virtual Task<byte[]> SetWatermarkAsync(byte[]? array, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => SetWatermark(array), cancellationToken);
        }
    }
}
