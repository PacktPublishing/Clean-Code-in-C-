using System;
using System.Runtime.Caching;

namespace CrossCuttingConcerns.Caching
{
    public static class MemoryCache
    {
        public static T GetItem<T>(string itemName, TimeSpan timeInCache, Func<T> itemCacheFunction)
        {
            var cache = System.Runtime.Caching.MemoryCache.Default;
            var cachedItem = (T) cache[itemName];
            if (cachedItem != null) return cachedItem;
            var policy = new CacheItemPolicy {AbsoluteExpiration = DateTimeOffset.Now.Add(timeInCache)};
            cachedItem = itemCacheFunction();
            cache.Set(itemName, cachedItem, policy);
            return cachedItem;
        }
    }
}
