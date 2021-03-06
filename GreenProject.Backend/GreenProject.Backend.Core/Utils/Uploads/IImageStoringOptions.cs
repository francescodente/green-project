namespace GreenProject.Backend.Core.Utils.Uploads
{
    public interface IImageStoringOptions
    {
        IImageStoringOptions Resize(Size targetSize);
        IImageStoringOptions SetDirectory(string directory);
        IImageStoringOptions SetName(string name);
        IImageStoringOptions SetFormat(ImageFormat format);
    }
}
