using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Shared.Utils
{
    public static class Optional
    {
        private class EmptyOptional<T> : IOptional<T>
        {
            public T Value => throw new InvalidOperationException("This optional is empty");

            public bool IsAbsent()
            {
                return true;
            }

            public bool IsPresent()
            {
                return false;
            }
        }

        private class LoadedOptional<T> : IOptional<T>
        {
            public T Value { get; private set; }

            public LoadedOptional(T value)
            {
                this.Value = value;
            }

            public bool IsAbsent()
            {
                return false;
            }

            public bool IsPresent()
            {
                return true;
            }
        }

        public static IOptional<T> Of<T>(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return new LoadedOptional<T>(value);
        }

        public static IOptional<T> OfNullable<T>(T value)
            where T : class
        {
            return value == null ? Empty<T>() : Of(value);
        }

        public static IOptional<T> OfNullable<T>(T? value)
            where T : struct
        {
            return value == null ? Empty<T>() : Of(value.Value);
        }

        public static IOptional<T> AsOptional<T>(this T? value)
            where T : struct
        {
            return OfNullable(value);
        }

        public static IOptional<T> AsOptional<T>(this T value)
            where T : class
        {
            return OfNullable(value);
        }

        public static IOptional<T> Empty<T>()
        {
            return new EmptyOptional<T>();
        }

        public static IOptional<T> TryCatch<T>(Func<T> supplier, Action<Exception> exceptionHandler = null)
        {
            return TryCatch<T, Exception>(supplier, exceptionHandler);
        }

        public static IOptional<TResult> TryCatch<TResult, TException>(Func<TResult> supplier, Action<TException> exceptionHandler = null)
            where TException : Exception
        {
            try
            {
                return Of(supplier());
            }
            catch (TException ex)
            {
                exceptionHandler?.Invoke(ex);
                return Empty<TResult>();
            }
        }

        public static Task<IOptional<T>> TryCatchAsync<T>(Func<Task<T>> supplier, Action<Exception> exceptionHandler = null)
        {
            return TryCatchAsync<T, Exception>(supplier, exceptionHandler);
        }

        public static async Task<IOptional<TResult>> TryCatchAsync<TResult, TException>(Func<Task<TResult>> supplier, Action<TException> exceptionHandler = null)
            where TException : Exception
        {
            try
            {
                return Of(await supplier());
            }
            catch (TException ex)
            {
                exceptionHandler?.Invoke(ex);
                return Empty<TResult>();
            }
        }

        public static IOptional<T> IfPresent<T>(this IOptional<T> optional, Action<T> action)
        {
            if (optional.IsPresent())
            {
                action(optional.Value);
            }
            return optional;
        }

        public static IOptional<T> IfAbsent<T>(this IOptional<T> optional, Action action)
        {
            if (optional.IsAbsent())
            {
                action();
            }
            return optional;
        }

        public static void IfElse<T>(this IOptional<T> optional, Action<T> ifPresent, Action ifAbsent)
        {
            if (optional.IsPresent())
            {
                ifPresent(optional.Value);
            }
            else
            {
                ifAbsent();
            }
        }

        public static IOptional<TResult> Map<TSource, TResult>(this IOptional<TSource> optional, Func<TSource, TResult> mapper)
        {
            return optional.IsPresent() ? Of(mapper(optional.Value)) : Empty<TResult>();
        }

        public static IOptional<T> Filter<T>(this IOptional<T> optional, Predicate<T> predicate)
        {
            return optional.IsPresent() && predicate(optional.Value) ? optional : Empty<T>();
        }

        public static IOptional<TResult> FlatMap<TSource, TResult>(this IOptional<TSource> optional, Func<TSource, IOptional<TResult>> mapper)
        {
            return optional.IsPresent() ? mapper(optional.Value) : Empty<TResult>();
        }

        public static IOptional<T> Flatten<T>(this IOptional<IOptional<T>> optional)
        {
            return optional.FlatMap(o => o);
        }

        public static T OrElse<T>(this IOptional<T> optional, T defaultValue)
        {
            return optional.IsPresent() ? optional.Value : defaultValue;
        }

        public static T OrElseGet<T>(this IOptional<T> optional, Func<T> supplier)
        {
            return optional.IsPresent() ? optional.Value : supplier();
        }

        public static T OrElseThrow<T>(this IOptional<T> optional, Func<Exception> exceptionSupplier)
        {
            if (optional.IsPresent())
            {
                return optional.Value;
            }
            else
            {
                throw exceptionSupplier();
            }
        }
    }
}
