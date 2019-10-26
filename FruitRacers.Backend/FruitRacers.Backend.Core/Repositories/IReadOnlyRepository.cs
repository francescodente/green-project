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
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAll();
    }
}
