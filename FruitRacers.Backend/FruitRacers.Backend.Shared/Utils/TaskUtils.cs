using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Shared.Utils
{
    public static class TaskUtils
    {
        public static Task<T> Then<T>(this Task task, Func<T> supplier)
        {
            return task.ContinueWith(t => supplier());
        }

        public static Task<TResult> Then<TSource, TResult>(this Task<TSource> task, Func<TSource, TResult> mapper)
        {
            return task.ContinueWith(t => mapper(t.Result));
        }
    }
}
