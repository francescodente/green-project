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

        public Task DeleteRange(IEnumerable<T> entities)
        {
            this.Set.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task Insert(T entity)
        {
            this.Set.Add(entity);
            return Task.CompletedTask;
        }

        public Task InsertRange(IEnumerable<T> entities)
        {
            this.Set.AddRange(entities);
            return Task.CompletedTask;
        }
    }
}
