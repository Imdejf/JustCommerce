using System;

namespace Watermark.Enums
{
    [Flags]
    public enum WatermarkOperation
    {
        AddPicture = 1,
        AddText = 2,
        AddSound = 4
    }
}
