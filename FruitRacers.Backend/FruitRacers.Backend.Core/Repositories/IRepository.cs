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

        Task InsertRange(IEnumerable<T> entities);

        Task Delete(T entity);

        Task DeleteRange(IEnumerable<T> entities);
    }
}
