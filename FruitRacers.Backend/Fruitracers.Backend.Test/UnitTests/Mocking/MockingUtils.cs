using FruitRacers.Backend.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fruitracers.Backend.Test.UnitTests.Mocking
{
    public static class MockingUtils
    {
        public static IReadOnlyRepository<T> CreateMockReadOnlyRepository<T>(IEnumerable<T> items)
            where T : class
        {
            IReadOnlyRepository<T> repository = Substitute.For<IReadOnlyRepository<T>>();

            repository
                .GetAll()
                .Returns(items);

            repository
                .Where(Arg.Any<Expression<Func<T, bool>>>())
                .Returns(p => items.Where(p.ArgAt<Expression<Func<T, bool>>>(0).Compile()));

            repository
                .FindOne(Arg.Any<Expression<Func<T, bool>>>())
                .Returns(p => items.Single(p.ArgAt<Expression<Func<T, bool>>>(0).Compile()));

            return repository;
        }
    }
}
