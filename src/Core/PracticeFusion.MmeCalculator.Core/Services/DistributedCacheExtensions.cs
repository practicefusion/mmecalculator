using Microsoft.Extensions.Caching.Distributed;
using System;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    internal static class DistributedCacheExtensions
    {
        public static bool Exists(this IDistributedCache cache, string key)
        {
            return cache.Get(key) != null;
        }

        public static T Get<T>(this IDistributedCache cache, string key)
        {
            return Get<T>(cache, key, true);
        }

        private static T Get<T>(this IDistributedCache cache, string key, bool bestEffort)
        {
            var data = cache?.Get(key);

            if (data == null && bestEffort)
            {
                return default!;
            }

            return JsonUtils.DeserializeFromUtf8Bytes<T>(new ReadOnlySpan<byte>(data));
        }

        public static bool TryGetValue<T>(this IDistributedCache cache, string key, out T value)
        {
            try
            {
                value = Get<T>(cache, key, false);
                if (value != null)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                value = default!;
                return false;
            }
        }

        public static void Set<T>(this IDistributedCache cache, string key, T value)
        {
            Set(cache, key, value, new DistributedCacheEntryOptions());
        }

        public static void Set<T>(this IDistributedCache cache, string key, T value,
            DistributedCacheEntryOptions options)
        {
            var bytes = JsonUtils.SerializeToUtf8Bytes(value);
            cache.Set(key, bytes, options);
        }
    }
}