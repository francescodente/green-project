using GreenProject.Backend.Core.Utils.Uploads;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Uploads
{
    public class LocalImageStorage : IImageStorage
    {
        private readonly string basePath;
        private readonly string defaultExtension;

        public LocalImageStorage(string basePath, string defaultExtension)
        {
            this.basePath = basePath;
            this.defaultExtension = defaultExtension;
        }

        public Task DeleteImageAtPath(string path)
        {
            string completePath = this.GetCompletePath(path);
            if (File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public Task<string> StoreImage(Stream imageStream, Action<IImageStoringOptions> options = null)
        {
            LocalImageStoringOptions storingOptions = new LocalImageStoringOptions();
            storingOptions.Extension = this.defaultExtension;
            options?.Invoke(storingOptions);

            string relativePath = Path.Combine(
                (storingOptions.Directory ?? ""),
                (storingOptions.Name ?? Guid.NewGuid().ToString()) + storingOptions.Extension);
            string completePath = this.GetCompletePath(relativePath);

            string dir = Path.GetDirectoryName(completePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (Image image = Image.Load(imageStream))
            {
                if (storingOptions.ImageModifier != null)
                {
                    image.Mutate(storingOptions.ImageModifier);
                }

                image.Save(completePath);
            }
            return Task.FromResult(relativePath);
        }

        private string GetCompletePath(string relativePath)
        {
            return Path.Combine(this.basePath, relativePath);
        }

        private class LocalImageStoringOptions : IImageStoringOptions
        {
            public Action<IImageProcessingContext> ImageModifier { get; set; }
            public string Directory { get; set; }
            public string Name { get; set; }
            public string Extension { get; set; }

            public IImageStoringOptions Resize(Size targetSize)
            {
                ResizeOptions options = new ResizeOptions
                {
                    Size = new SixLabors.Primitives.Size(targetSize.Width, targetSize.Height),
                    Position = AnchorPositionMode.Center,
                    Mode = ResizeMode.Crop
                };
                this.ImageModifier += x => x.Resize(options);
                return this;
            }

            public IImageStoringOptions SetDirectory(string directory)
            {
                this.Directory = directory;
                return this;
            }

            public IImageStoringOptions SetFormat(ImageFormat format)
            {
                this.Extension = format.GetExtension();
                return this;
            }

            public IImageStoringOptions SetName(string name)
            {
                this.Name = name;
                return this;
            }
        }
    }
}
