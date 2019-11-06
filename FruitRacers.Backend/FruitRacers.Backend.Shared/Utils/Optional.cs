using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Shared.Utils
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

        public static IOptional<T> Empty<T>()
        {
            return new EmptyOptional<T>();
        }

        public static void IfPresent<T>(this IOptional<T> optional, Action<T> action)
        {
            if (optional.IsPresent())
            {
                action(optional.Value);
            }
        }

        public static void IfAbsent<T>(this IOptional<T> optional, Action action)
        {
            if (optional.IsAbsent())
            {
                action();
            }
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
            return optional.IsPresent() ? optional.Value : throw exceptionSupplier();
        }
    }
}
