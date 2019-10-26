using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class ReadOnlySqlRepository<T> : AbstractSqlRepository, IReadOnlyRepository<T>
        where T : class
    {
        protected DbSet<T> Set => this.Context.Set<T>();
        private Func<IQueryable<T>, IQueryable<T>> queryModifier;

        public ReadOnlySqlRepository(FruitracersContext context) : base(context)
        {
            this.queryModifier = q => q;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.AsQueryable().ToArrayAsync();
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await this.AsQueryable().Where(predicate).ToArrayAsync();
        }

        protected IQueryable<T> AsQueryable()
        {
            return this.queryModifier(this.Set);
        }

        protected void ChainQueryModification(Func<IQueryable<T>, IQueryable<T>> modifier)
        {
            Func<IQueryable<T>, IQueryable<T>> current = this.queryModifier;
            this.queryModifier = q => modifier(current(q));
        }
    }
}
