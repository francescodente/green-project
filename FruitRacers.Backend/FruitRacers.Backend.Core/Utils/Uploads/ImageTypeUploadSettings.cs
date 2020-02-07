using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils.Uploads
{
    public class ImageTypeUploadSettings
    {
        public Size Size { get; set; }
        public string DirectoryTemplate { get; set; }
        public string Name { get; set; }
        public ImageFormat? Format { get; set; }
    }
}
