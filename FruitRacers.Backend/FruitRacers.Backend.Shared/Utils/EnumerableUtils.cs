using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.Shared.Utils
{
    public static class EnumerableUtils
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T item in sequence)
            {
                action(item);
            }
        }

        public static IOptional<T> SingleOptional<T>(this IEnumerable<T> sequence)
        {
            IEnumerator<T> enumerator = sequence.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return Optional.Empty<T>();
            }
            T itemToReturn = enumerator.Current;
            if (enumerator.MoveNext())
            {
                return Optional.Empty<T>();
            }
            return Optional.Of(itemToReturn);
        }

        public static IOptional<T> SingleOptional<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            return sequence.Where(predicate).SingleOptional();
        }
    }
}
