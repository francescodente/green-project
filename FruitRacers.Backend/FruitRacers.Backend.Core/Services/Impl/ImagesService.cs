using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Core.Utils.Uploads;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
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
            Action<IImageStoringOptions> storingOptions = options =>
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
            };

            return new ImageResource(this.storage, storingOptions, imageSupplier, imageSetter, this.Data);
        }

        public async Task<IImageResource> CategoryImage(int categoryId)
        {
            Category category = await this.Data
                .Categories
                .FindOne(c => c.CategoryId == categoryId)
                .Then(c => c.OrElseThrow(() => new CategoryNotFoundException(categoryId)));

            return this.CreateImageResource(
                () => category.Image,
                img => category.Image = img,
                this.settings.Categories,
                categoryId);
        }

        public async Task<IImageResource> ProductImage(int productId, int supplierId)
        {
            Product product = await this.Data
                .Products
                .FindOne(p => p.ProductId == productId)
                .Then(p => p.OrElseThrow(() => new ProductNotFoundException(productId)));

            ServiceUtils.RequireOwnership(product.SupplierId, supplierId);

            return this.CreateImageResource(
                () => product.Image,
                img => product.Image = img,
                this.settings.Products,
                productId);
        }

        private async Task<Supplier> FindSupplier(int supplierId)
        {
            return await this.Data
                .Suppliers
                .FindOne(s => s.UserId == supplierId)
                .Then(s => s.OrElseThrow(() => UserNotFoundException.WithId(supplierId)));
        }

        public async Task<IImageResource> SupplierBackgroundImage(int supplierId)
        {
            Supplier supplier = await this.FindSupplier(supplierId);
            return this.CreateImageResource(
                () => supplier.BackgroundImage,
                img => supplier.BackgroundImage = img,
                this.settings.SupplierBackgroundImages,
                supplierId);
        }

        public async Task<IImageResource> SupplierLogo(int supplierId)
        {
            Supplier supplier = await this.FindSupplier(supplierId);
            return this.CreateImageResource(
                () => supplier.LogoImage,
                img => supplier.LogoImage = img,
                this.settings.SupplierLogos,
                supplierId);
        }
    }
}
