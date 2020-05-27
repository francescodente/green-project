using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Core.Utils.Uploads;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class ImagesService : AbstractService, IImagesService
    {
        private readonly IImageStorage _storage;
        private readonly ImageUploadSettings _settings;

        public ImagesService(IRequestSession request, IImageStorage storage, ImageUploadSettings settings)
            : base(request)
        {
            _storage = storage;
            _settings = settings;
        }

        private IImageResource CreateImageResource(Func<Image> imageSupplier, Action<Image> imageSetter, ImageTypeUploadSettings imageSettings, params object[] directoryParams)
        {
            void storingOptions(IImageStoringOptions options)
            {
                imageSettings
                    .Format
                    .AsOptional()
                    .IfPresent(f => options.SetFormat(f));
                imageSettings
                    .Size
                    .AsOptional()
                    .IfPresent(s => options.Resize(s));
                imageSettings
                    .DirectoryTemplate
                    .AsOptional()
                    .Map(d => string.Format(d, directoryParams))
                    .IfPresent(d => options.SetDirectory(d));
                imageSettings
                    .Name
                    .AsOptional()
                    .IfPresent(n => options.SetName(n));
            }

            return new ImageResource(_storage, storingOptions, imageSupplier, imageSetter, Data);
        }

        public async Task<IImageResource> CategoryImage(int categoryId)
        {
            Category category = await Data
                .Categories
                .Include(c => c.Image)
                .SingleOptionalAsync(c => c.CategoryId == categoryId)
                .Map(c => c.OrElseThrow(() => NotFoundException.CategoryWithId(categoryId)));

            return CreateImageResource(
                () => category.Image,
                img => category.Image = img,
                _settings.Categories,
                categoryId);
        }

        public async Task<IImageResource> PurchasableImage(int itemId)
        {
            PurchasableItem item = await Data
                .ActivePurchasableItems()
                .Include(p => p.Image)
                .SingleOptionalAsync(p => p.ItemId == itemId)
                .Map(p => p.OrElseThrow(() => NotFoundException.PurchasableItemWithId(itemId)));

            return CreateImageResource(
                () => item.Image,
                img => item.Image = img,
                _settings.PurchasableItems,
                itemId);
        }
    }
}
