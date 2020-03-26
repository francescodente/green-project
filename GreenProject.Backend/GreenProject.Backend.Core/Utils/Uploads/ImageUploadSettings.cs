using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.Uploads
{
    public class ImageUploadSettings
    {
        public ImageFormat DefaultFormat { get; set; }
        public ImageTypeUploadSettings Categories { get; set; }
        public ImageTypeUploadSettings Products { get; set; }
        public ImageTypeUploadSettings SupplierLogos { get; set; }
        public ImageTypeUploadSettings SupplierBackgroundImages { get; set; }
    }
}
