using FruitRacers.Backend.Core.Utils.Uploads;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IImagesService
    {
        Task<IImageResource> ProductImage(int productId);

        Task<IImageResource> CategoryImage(int categoryId);

        Task<IImageResource> SupplierLogo(int supplierId);

        Task<IImageResource> SupplierBackgroundImage(int supplierId);
    }
}
