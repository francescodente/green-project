using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Session;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Uploads
{
    public class ImageResource : IImageResource
    {
        private readonly IImageStorage storage;
        private readonly Action<IImageStoringOptions> storingOptions;
        private readonly Func<Image> imageSupplier;
        private readonly Action<Image> imageSetter;
        private readonly IDataSession data;

        public ImageResource(
            IImageStorage storage,
            Action<IImageStoringOptions> storingOptions,
            Func<Image> imageSupplier,
            Action<Image> imageSetter,
            IDataSession data)
        {
            this.imageSupplier = imageSupplier;
            this.imageSetter = imageSetter;
            this.storage = storage;
            this.storingOptions = storingOptions;
            this.data = data;
        }

        public async Task Delete()
        {
            Image currentImage = this.imageSupplier();
            if (currentImage == null)
            {
                throw NotFoundException.Image();
            }
            await storage.DeleteImageAtPath(currentImage.Path);
            this.data.Images.Remove(currentImage);
            await this.data.SaveChangesAsync();
        }

        public async Task Store(Stream imageStream)
        {
            Image currentImage = this.imageSupplier();
            if (currentImage != null)
            {
                await storage.DeleteImageAtPath(currentImage.Path);
            }
            string newPath = await storage.StoreImage(imageStream, this.storingOptions);
            if (currentImage == null)
            {
                currentImage = new Image();
                this.imageSetter(currentImage);
            }
            currentImage.Path = newPath;
            await this.data.SaveChangesAsync();
        }
    }
}
