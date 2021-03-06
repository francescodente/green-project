using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Shared.Utils
{
    public static class DictionaryUtils
    {
        public static IOptional<TValue> GetValueAsOptional<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.TryGetValue(key, out TValue value))
            {
                return Optional.Of(value);
            }
            return Optional.Empty<TValue>();
        }

        public static void Merge<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value,
            Func<TValue, TValue, TValue> combiner)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = combiner(dictionary[key], value);
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}
