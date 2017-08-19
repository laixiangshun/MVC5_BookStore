using BooksStore.Utils;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BooksStore.Common.Cache
{
    public class RedisCacheManager:ICacheManager
    {
        private readonly string redisConnenctionString;
        public volatile ConnectionMultiplexer redisConnection;
        private readonly object redisConnectionLock = new object();

        public RedisCacheManager()
        {
            //连接redis服务语句
            string redisConfiguration = ConfigurationManager.ConnectionStrings["redisCache"].ToString();
            if (string.IsNullOrWhiteSpace(redisConfiguration))
            {
                throw new ArgumentException("redis config is empty",redisConfiguration.GetType().FullName);
            }
            this.redisConnenctionString = redisConfiguration;
            this.redisConnection = GetRedisConnetion();
        }
        private ConnectionMultiplexer GetRedisConnetion()
        {
            if (this.redisConnection != null && this.redisConnection.IsConnected)
            {
                return this.redisConnection;
            }
            lock (redisConnectionLock)
            {
                if (this.redisConnection != null)
                {
                    //释放redis连接
                    this.redisConnection.Dispose();
                }
                this.redisConnection = ConnectionMultiplexer.Connect(redisConnenctionString);
            }
            return this.redisConnection;
        }
        public TEntity Get<TEntity>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                return SerializeHelper.Deserialize<TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }

        public void Set(string key, object value, TimeSpan cacheTiume)
        {
            if (value != null)
            {
                redisConnection.GetDatabase().StringSet(key, SerializeHelper.Serialize(value), cacheTiume);
            }
        }

        public bool Contains(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
        }

        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnetion().GetEndPoints())
            {
                var server = this.GetRedisConnetion().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }
    }
}