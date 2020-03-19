using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Logic
{
    public class AdminService : AbstractService, IAdminService
    {
        public AdminService(IRequestSession request)
            : base(request)
        {
        }

        public async Task SetProductEnabledState(int productId, bool enabled)
        {
            Product product = await this.Data
                .Products
                .SingleOptionalAsync(p => p.ProductId == productId)
                .Map(s => s.OrElseThrow(() => new ProductNotFoundException(productId)));

            product.IsLegal = enabled;
            await this.Data.SaveChangesAsync();
        }

        public async Task SetUserEnabledState(int userId, bool enabled)
        {
            User user = await this.Data
                .Users
                .SingleOptionalAsync(s => s.UserId == userId)
                .Map(s => s.OrElseThrow(() => UserNotFoundException.WithId(userId)));

            user.IsEnabled = enabled;
            await this.Data.SaveChangesAsync();
        }
    }
}
