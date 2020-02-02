using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils.Uploads
{
    public enum ImageFormat
    {
        Png,
        Jpeg,
        Bmp,
        Gif
    }

    public static class ImageFormatExtensions
    {
        public static string GetExtension(this ImageFormat format)
        {
            switch (format)
            {
                case ImageFormat.Png:
                    return ".png";
                case ImageFormat.Jpeg:
                    return ".jpg";
                case ImageFormat.Bmp:
                    return ".bmp";
                case ImageFormat.Gif:
                    return ".gif";
                default:
                    return null;
            }
        }
    }
}
