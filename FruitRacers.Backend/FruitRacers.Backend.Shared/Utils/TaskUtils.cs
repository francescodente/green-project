using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Shared.Utils
{
    public static class TaskUtils
    {
        public static async Task Then<T>(this Task<T> task, Action<T> taskContinuation)
        {
            taskContinuation(await task);
        }

        public static async Task Then<T>(this Task<T> task, Func<T, Task> taskContinuation)
        {
            await taskContinuation(await task);
        }

        public static async Task<TResult> Map<TSource, TResult>(this Task<TSource> task, Func<TSource, TResult> mapper)
        {
            return mapper(await task);
        }

        public static async Task<TResult> FlatMap<TSource, TResult>(this Task<TSource> task, Func<TSource, Task<TResult>> taskContinuation)
        {
            return await taskContinuation(await task);
        }
    }
}
