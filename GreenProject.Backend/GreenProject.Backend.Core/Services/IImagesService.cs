using GreenProject.Backend.Core.Utils.Uploads;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IImagesService
    {
        Task<IImageResource> PurchasableImage(int purchasableId);

        Task<IImageResource> CategoryImage(int categoryId);
    }
}
