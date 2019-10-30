using System;
using System.Collections.Generic;
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
    }
}
