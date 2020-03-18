using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.DataAccess.Sql.Repositories;
using System.Threading.Tasks;

namespace FruitRacers.Backend.DataAccess.Sql
{
    public class SqlDataSession : IDataSession
    {
        private readonly FruitracersContext context;

        public SqlDataSession(FruitracersContext context)
        {
            this.context = context;
        }

        public IUserRepository Users => new SqlUserRepository(this.context);

        public IOrderRepository Orders => new SqlOrderRepository(this.context);

        public IProductRepository Products => new SqlProductRepository(this.context);

        public ITimeSlotRepository TimeSlots => new SqlTimeSlotRepository(this.context);

        public IReadOnlyRepository<Category> Categories => new SqlCategoryRepository(this.context);

        public IReadOnlyRepository<Supplier> Suppliers => new SqlSupplierRepository(this.context);

        public IRepository<Image> Images => new SqlImageRepository(this.context);

        public ISectionRepository Sections => new SqlSectionRepository(this.context);

        public void Dispose()
        {
            this.context.Dispose();
        }

        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
