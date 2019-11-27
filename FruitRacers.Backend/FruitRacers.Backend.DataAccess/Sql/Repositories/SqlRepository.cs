using FruitRacers.Backend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlRepository<T> : ReadOnlySqlRepository<T>, IRepository<T> where T : class
    {
        public SqlRepository(FruitracersContext context)
            : base(context)
        {

        }

        public SqlRepository(FruitracersContext context, Func<IQueryable<T>, IQueryable<T>> initialModifier)
            : base(context, initialModifier)
        {

        }

        public Task Delete(T entity)
        {
            this.Set.Remove(entity);
            return Task.CompletedTask;
        }

        public Task Insert(T entity)
        {
            this.Set.Add(entity);
            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            this.Set.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entitiesToDelete = await this.Where(predicate);
            this.Set.RemoveRange(entitiesToDelete);
        }

        public async Task UpdateWhere(Expression<Func<T, bool>> predicate, Action<T> updateAction)
        {
            IEnumerable<T> entitiesToUpdate = await this.Where(predicate);
            entitiesToUpdate.ForEach(updateAction);
        }
    }
}
