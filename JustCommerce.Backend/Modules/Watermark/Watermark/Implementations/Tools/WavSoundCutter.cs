using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using Watermark.Interfaces.Tools;

namespace Watermark.Implementations.Tools
{
    internal sealed class WavSoundCutter : IWavSoundCutter
    {
        public List<byte[]> Cut(byte[] musicArray, int intervalBetweenSound, int totalTimeSeconds)
        {
            List<byte[]> streams = new List<byte[]>();
            for (int a = 0; a < totalTimeSeconds; a += intervalBetweenSound)
            {
                using (var stream = new MemoryStream(musicArray))
                {
                    byte[] trimedPieceOfMusic;
                    if (totalTimeSeconds - (a + intervalBetweenSound) < 0)
                    {
                        trimedPieceOfMusic = trimWavFile(stream, new TimeSpan(0, 0, a), new TimeSpan(0, 0, 0));
                        streams.Add(trimedPieceOfMusic);                        
                        break;
                    }
                    trimedPieceOfMusic = trimWavFile(
                        stream,
                        new TimeSpan(0, 0, a),
                        new TimeSpan(0, 0, WatermarkHelper.GetRoundTime(totalTimeSeconds) - (a + intervalBetweenSound))
                    );
                    streams.Add(trimedPieceOfMusic);                    
                }
            }
            return streams;
        }

        public List<byte[]> CutAudioFromVideo(byte[] musicArray, int intervalBetweenSound, int totalMusicTimeSeconds, int totalSoundTimeSeconds)
        {
            int startPos = 0;
            List<byte[]> streams = new List<byte[]>();
            for (int time = 0; time < totalMusicTimeSeconds; time += intervalBetweenSound)
            {
                if (time > 0)
                {
                    startPos = time + totalSoundTimeSeconds;
                }
                using (var audionStream = new MemoryStream(musicArray))
                {

                    if (totalMusicTimeSeconds - (time + intervalBetweenSound) < 0)
                    {
                        var trimed = trimWavFile(audionStream, new TimeSpan(0, 0, (time + totalSoundTimeSeconds)), new TimeSpan(0, 0, 0));
                        streams.Add(trimed);
                        break;
                    }

                    var stream = trimWavFile(
                        audionStream,
                        new TimeSpan(0, 0, startPos),
                        new TimeSpan(0, 0, WatermarkHelper.GetRoundTime(totalMusicTimeSeconds) - ((time + intervalBetweenSound)))
                    );
                    streams.Add(stream);
                }
            }
            return streams;
        }

        private MemoryStream trimWavFile(WaveFileReader reader, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            using (var stream = new MemoryStream())
            {
                using (var writer = new WaveFileWriter(stream, reader.WaveFormat))
                {
                    while (reader.Position < endPos)
                    {
                        int bytesRequired = (int)(endPos - reader.Position);
                        if (bytesRequired > 0)
                        {
                            int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                            int bytesRead = reader.Read(buffer, 0, bytesToRead - (bytesToRead % reader.WaveFormat.BlockAlign));
                            if (bytesRead > 0)
                            {
                                writer.WriteData(buffer, 0, bytesRead);
                            }
                        }
                    }
                    return stream;
                }
            }
        }
        private byte[] trimWavFile(MemoryStream inPath, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (WaveFileReader reader = new WaveFileReader(inPath))
            {
                int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                int endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
                int endPos = (int)reader.Length - endBytes;

                return trimWavFile(reader, startPos, endPos).ToArray();
            }
        }
    }
}
