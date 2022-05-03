using System.Collections.Generic;
using System.IO;

namespace Watermark.Interfaces.Tools
{
    internal interface IWavSoundConcatenater
    {
        MemoryStream Concatenate(MemoryStream outputFile, IEnumerable<byte[]> sourceFiles);
    }
}
