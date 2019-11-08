using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Shared.Utils;
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
                .Returns(_ => items);

            repository
                .Where(Arg.Any<Expression<Func<T, bool>>>())
                .Returns(p => items.Where(p.ArgAt<Expression<Func<T, bool>>>(0).Compile()));

            repository
                .FindOne()
                .Returns(_ => items.SingleOptional());

            repository
                .FindOne(Arg.Any<Expression<Func<T, bool>>>())
                .Returns(p => items.SingleOptional(p.ArgAt<Expression<Func<T, bool>>>(0).Compile()));

            return repository;
        }
    }
}
