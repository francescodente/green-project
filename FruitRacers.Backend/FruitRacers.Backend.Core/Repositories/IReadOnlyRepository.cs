using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface IReadOnlyRepository<T> where T : class
    {
        Task<IOptional<T>> FindOne(Expression<Func<T, bool>> predicate = null);

        Task<IEnumerable<T>> AsEnumerable(Expression<Func<T, bool>> predicate = null);

        Task<IEnumerable<T>> AsPagedEnumerable(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null);

        Task<int> Count(Expression<Func<T, bool>> predicate = null);
    }
}
