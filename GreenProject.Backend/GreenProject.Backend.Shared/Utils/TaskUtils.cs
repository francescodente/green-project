using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Shared.Utils
{
    public static class TaskUtils
    {
        public static async Task Then(this Task task, Action taskContinuation)
        {
            await task;
            taskContinuation();
        }

        public static async Task Then(this Task task, Func<Task> taskContinuation)
        {
            await task;
            await taskContinuation();
        }

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

        public static async void FireAndForget(this Task task)
        {
            await task;
        }

        public static async void FireAndForget<TException>(this Task task, Action<TException> exceptionHandler)
            where TException : Exception
        {
            try
            {
                await task;
            }
            catch (TException ex)
            {
                exceptionHandler(ex);
            }
        }
    }
}
