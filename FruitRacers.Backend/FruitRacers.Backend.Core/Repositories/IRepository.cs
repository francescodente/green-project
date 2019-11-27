using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        Task Insert(T entity);

        Task Delete(T entity);

        Task DeleteWhere(Expression<Func<T, bool>> predicate);

        Task Update(T entity);

        Task UpdateWhere(Expression<Func<T, bool>> predicate, Action<T> updateAction);
    }
}
