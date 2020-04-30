using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenProject.Backend.Shared.Utils
{
    public static class EnumerableUtils
    {
        public static IEnumerable<T> Iterate<T>(T seed, Func<T, T> next)
        {
            T curr = seed;
            while (true)
            {
                yield return curr;
                curr = next(curr);
            }
        }

        public static IEnumerable<T> Generate<T>(Func<T> supplier)
        {
            while (true)
            {
                yield return supplier();
            }
        }

        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T item in sequence)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Peek<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T item in sequence)
            {
                action(item);
                yield return item;
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

        public static string ConcatStrings<T>(this IEnumerable<T> sequence)
        {
            return sequence.ConcatStrings(string.Empty);
        }

        public static string ConcatStrings<T>(this IEnumerable<T> sequence, string separator)
        {
            return sequence.ConcatStrings(separator, string.Empty, string.Empty);
        }

        public static string ConcatStrings<T>(this IEnumerable<T> sequence, string separator, string prefix, string suffix)
        {
            return new StringBuilder()
                .Append(prefix)
                .AppendJoin(separator, sequence)
                .Append(suffix)
                .ToString();
        }

        public static IEnumerable<DateTime> EnumerateDates(DateTime start)
        {
            return Iterate(start, d => d.AddDays(1));
        }
    }
}
