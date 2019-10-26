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
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
