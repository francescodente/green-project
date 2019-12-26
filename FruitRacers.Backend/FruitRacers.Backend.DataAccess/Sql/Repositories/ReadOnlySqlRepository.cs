using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Shared.Utils;
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

        public ReadOnlySqlRepository(FruitracersContext context)
            : this(context, q => q)
        {
        }

        public ReadOnlySqlRepository(FruitracersContext context, Func<IQueryable<T>, IQueryable<T>> initialModifier)
            : base(context)
        {
            this.queryModifier = initialModifier;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.AsQueryable()
                .ToArrayAsync();
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await this.AsQueryable()
                .Where(predicate)
                .ToArrayAsync();
        }

        protected IQueryable<T> AsQueryable()
        {
            return this.queryModifier(this.Set);
        }

        protected Func<IQueryable<T>, IQueryable<T>> WrapQuery(Func<IQueryable<T>, IQueryable<T>> modifier)
        {
            return q => modifier(this.queryModifier(q));
        }

        public async Task<IOptional<T>> FindOne()
        {
            return await Optional.TryCatchAsync(() => this.AsQueryable().SingleAsync());
        }

        public async Task<IOptional<T>> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await Optional.TryCatchAsync(() => this.AsQueryable().SingleAsync(predicate));
        }
    }
}
