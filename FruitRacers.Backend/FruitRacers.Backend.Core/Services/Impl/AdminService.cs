using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
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
                .FindOne(p => p.ProductId == productId)
                .Then(s => s.OrElseThrow(() => new ProductNotFoundException(productId)));

            product.IsLegal = enabled;
            await this.Data.SaveChanges();
        }

        public async Task SetUserEnabledState(int userId, bool enabled)
        {
            User user = await this.Data
                .Users
                .FindOne(s => s.UserId == userId)
                .Then(s => s.OrElseThrow(() => UserNotFoundException.WithId(userId)));

            user.IsEnabled = enabled;
            await this.Data.SaveChanges();
        }
    }
}
