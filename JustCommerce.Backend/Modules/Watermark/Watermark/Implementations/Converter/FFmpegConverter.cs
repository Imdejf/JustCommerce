using System.Diagnostics;
using System.IO;

namespace Watermark.Implementations.Converter
{
    internal sealed class FFmpegConverter
    {
        ProcessStartInfo info = new ProcessStartInfo()
        {
            FileName = Directory.GetCurrentDirectory().Split("Watermark")[0] + "Watermark\\Watermark\\FFmpeg\\ffmpeg.exe",
            WorkingDirectory = Directory.GetCurrentDirectory().Split("Watermark")[0] + "Watermark\\Watermark\\FFmpeg",
            CreateNoWindow = true,
            UseShellExecute = false
        };
        public FFmpegConverter(string argument)
        {            
            info.Arguments = argument;
        }
        public void Start()
        {
            using (var procces = new Process() { StartInfo = info })
            {
                procces.Start();
                procces.WaitForExit();                
            }
        }
    }
}
