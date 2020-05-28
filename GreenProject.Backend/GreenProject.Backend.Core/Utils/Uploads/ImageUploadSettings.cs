namespace GreenProject.Backend.Core.Utils.Uploads
{
    public class ImageUploadSettings
    {
        public string BaseFolder { get; set; }
        public ImageFormat DefaultFormat { get; set; }
        public ImageTypeUploadSettings Categories { get; set; }
        public ImageTypeUploadSettings PurchasableItems { get; set; }
    }
}
