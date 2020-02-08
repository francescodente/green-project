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
            return format switch
            {
                ImageFormat.Png => ".png",
                ImageFormat.Jpeg => ".jpg",
                ImageFormat.Bmp => ".bmp",
                ImageFormat.Gif => ".gif",
                _ => null,
            };
        }
    }
}
