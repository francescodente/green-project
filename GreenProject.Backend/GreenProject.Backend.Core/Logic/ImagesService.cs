using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Core.Utils.Uploads;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class ImagesService : AbstractService, IImagesService
    {
        private readonly IImageStorage storage;
        private readonly ImageUploadSettings settings;

        public ImagesService(IRequestSession request, IImageStorage storage, ImageUploadSettings settings)
            : base(request)
        {
            this.storage = storage;
            this.settings = settings;
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

            return new ImageResource(this.storage, storingOptions, imageSupplier, imageSetter, this.Data);
        }

        public async Task<IImageResource> CategoryImage(int categoryId)
        {
            Category category = await this.Data
                .Categories
                .SingleOptionalAsync(c => c.CategoryId == categoryId)
                .Map(c => c.OrElseThrow(() => NotFoundException.CategoryWithId(categoryId)));

            return this.CreateImageResource(
                () => category.Image,
                img => category.Image = img,
                this.settings.Categories,
                categoryId);
        }

        public async Task<IImageResource> PurchasableImage(int productId)
        {
            Product product = await this.Data
                .Products
                .Include(p => p.Image)
                .SingleOptionalAsync(p => p.ItemId == productId)
                .Map(p => p.OrElseThrow(() => NotFoundException.ProductWithId(productId)));

            return this.CreateImageResource(
                () => product.Image,
                img => product.Image = img,
                this.settings.Products,
                productId);
        }
    }
}
