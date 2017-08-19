using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
namespace BooksStore.Common.Cache
{
    public class MemoryCacheManager:ICacheManager
    {
        public TEntity Get<TEntity>(string key)
        {
            return (TEntity)MemoryCache.Default.Get(key);
        }

        public void Set(string key, object value, TimeSpan cacheTiume)
        {
            MemoryCache.Default.Add(key, value, new CacheItemPolicy { SlidingExpiration = cacheTiume });
        }

        public bool Contains(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public void Clear()
        {
            foreach (var item in MemoryCache.Default)
            {
                this.Remove(item.Key);
            }
        }
    }
}