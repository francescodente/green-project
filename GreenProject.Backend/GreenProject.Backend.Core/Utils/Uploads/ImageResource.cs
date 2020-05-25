using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Uploads
{
    public class ImageResource : IImageResource
    {
        private readonly IImageStorage _storage;
        private readonly Action<IImageStoringOptions> _storingOptions;
        private readonly Func<Image> _imageSupplier;
        private readonly Action<Image> _imageSetter;
        private readonly IDataSession _data;

        public ImageResource(
            IImageStorage storage,
            Action<IImageStoringOptions> storingOptions,
            Func<Image> imageSupplier,
            Action<Image> imageSetter,
            IDataSession data)
        {
            _imageSupplier = imageSupplier;
            _imageSetter = imageSetter;
            _storage = storage;
            _storingOptions = storingOptions;
            _data = data;
        }

        public async Task Delete()
        {
            Image currentImage = _imageSupplier();
            if (currentImage == null)
            {
                throw NotFoundException.Image();
            }
            await _storage.DeleteImageAtPath(currentImage.Path);
            _data.Images.Remove(currentImage);
            await _data.SaveChangesAsync();
        }

        public async Task Store(Stream imageStream)
        {
            Image currentImage = _imageSupplier();
            if (currentImage != null)
            {
                await _storage.DeleteImageAtPath(currentImage.Path);
            }
            string newPath = await _storage.StoreImage(imageStream, _storingOptions);
            if (currentImage == null)
            {
                currentImage = new Image();
                _imageSetter(currentImage);
            }
            currentImage.Path = newPath;
            await _data.SaveChangesAsync();
        }
    }
}
