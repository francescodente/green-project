using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Uploads
{
    public class ImageResource : IImageResource
    {
        private readonly IImageStorage storage;
        private readonly Action<IImageStoringOptions> storingOptions;
        private readonly Func<Image> imageSupplier;
        private readonly Action<Image> imageSetter;
        private readonly Func<Task> saveAction;

        public ImageResource(
            IImageStorage storage,
            Action<IImageStoringOptions> storingOptions,
            Func<Image> imageSupplier,
            Action<Image> imageSetter,
            Func<Task> saveAction)
        {
            this.imageSupplier = imageSupplier;
            this.imageSetter = imageSetter;
            this.storage = storage;
            this.storingOptions = storingOptions;
            this.saveAction = saveAction;
        }

        public async Task Delete()
        {
            Image currentImage = this.imageSupplier();
            if (currentImage is null)
            {
                throw new NotFoundException(); // TODO: use proper exception
            }
            await storage.DeleteImageAtPath(currentImage.Path);
            this.imageSetter(null);
            await this.saveAction();
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
            await this.saveAction();
        }
    }
}
