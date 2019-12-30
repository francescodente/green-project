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

        protected IQueryable<T> AsQueryable()
        {
            return this.queryModifier(this.Set);
        }

        protected Func<IQueryable<T>, IQueryable<T>> WrapQuery(Func<IQueryable<T>, IQueryable<T>> modifier)
        {
            return q => modifier(this.queryModifier(q));
        }

        private IQueryable<T> AsFilteredQueryable(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.AsQueryable();
            return predicate != null ? query.Where(predicate) : query;
        }

        public async Task<IEnumerable<T>> AsEnumerable(Expression<Func<T, bool>> predicate = null)
        {
            return await this.AsFilteredQueryable(predicate).ToArrayAsync();
        }

        public async Task<IOptional<T>> FindOne(Expression<Func<T, bool>> predicate = null)
        {
            return await Optional.TryCatchAsync(() => this.AsFilteredQueryable(predicate).SingleAsync());
        }

        public async Task<IEnumerable<T>> AsPagedEnumerable(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null)
        {
            return await this.AsFilteredQueryable(predicate)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToArrayAsync();
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null)
        {
            return await this.AsFilteredQueryable(predicate).CountAsync();
        }
    }
}
