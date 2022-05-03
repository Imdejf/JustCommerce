using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using Watermark.Interfaces.Tools;

namespace Watermark.Implementations.Tools
{
    internal sealed class WavSoundConcatenater : IWavSoundConcatenater
    {
        public MemoryStream Concatenate(MemoryStream outputFile, IEnumerable<byte[]> sourceFiles)
        {
            byte[] buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;

            try
            {
                using (var updatedSound = new MemoryStream())
                {
                    foreach (var sourceFile in sourceFiles)
                    {
                        using (var stream = new MemoryStream(sourceFile))
                        {
                            using (WaveFileReader reader = new WaveFileReader(stream))
                            {
                                if (waveFileWriter == null)
                                {

                                    waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
                                }
                                else
                                {
                                    if (reader.WaveFormat.Encoding != waveFileWriter.WaveFormat.Encoding)
                                    {
                                        throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                                    }
                                }

                                int read;
                                while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    waveFileWriter.Write(buffer, 0, read);
                                    updatedSound.Write(buffer, 0, read);
                                }
                            }
                        }
                    }
                    return updatedSound;
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }
        }

    }
}
