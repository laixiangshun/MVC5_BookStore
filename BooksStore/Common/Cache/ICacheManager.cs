using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Common.Cache
{
    public interface ICacheManager
    {
        TEntity Get<TEntity>(string key);
        //设置
        void Set(string key, object value, TimeSpan cacheTiume);
        //判断是否存在
        bool Contains(string key);
        //移除
        void Remove(string key);
        //清除
        void Clear();
    }
}
