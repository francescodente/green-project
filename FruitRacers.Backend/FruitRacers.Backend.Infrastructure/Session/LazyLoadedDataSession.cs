using System.Threading.Tasks;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;

namespace FruitRacers.Backend.Infrastructure.Session
{
    public class LazyLoadedDataSession : IDataSession
    {
        private readonly IDataSession session;

        private IUserRepository users;
        private IOrderRepository orders;
        private IProductRepository products;
        private ITimeSlotRepository timeSlots;
        private IReadOnlyRepository<Category> categories;
        private IReadOnlyRepository<Supplier> suppliers;
        private IRepository<Image> images;

        public LazyLoadedDataSession(IDataSession session)
        {
            this.session = session;
        }

        public IUserRepository Users => users ?? (users = session.Users);

        public IOrderRepository Orders => orders ?? (orders = session.Orders);

        public IProductRepository Products => products ?? (products = session.Products);

        public ITimeSlotRepository TimeSlots => timeSlots ?? (timeSlots = session.TimeSlots);

        public IReadOnlyRepository<Category> Categories => categories ?? (categories = session.Categories);

        public IReadOnlyRepository<Supplier> Suppliers => suppliers ?? (suppliers = session.Suppliers);

        public IRepository<Image> Images => images ?? (images = session.Images);

        public void Dispose()
        {
            session.Dispose();
        }

        public async Task SaveChanges()
        {
            await session.SaveChanges();
        }
    }
}
