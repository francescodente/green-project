namespace GreenProject.Backend.Core.Utils.Uploads
{
    public class ImageTypeUploadSettings
    {
        public Size Size { get; set; }
        public string DirectoryTemplate { get; set; }
        public string Name { get; set; }
        public ImageFormat? Format { get; set; }
    }
}
