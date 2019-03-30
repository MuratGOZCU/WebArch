using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace YK.Core.Caching
{
    public class MemoryCacheManager : IStaticCacheManager
    {
        #region Fields

        private readonly IMemoryCache _cache;

        private CancellationTokenSource _cancellationTokenSource;

        private static readonly ConcurrentDictionary<string, bool> _allKeys;

        #endregion

        #region Ctor

        static MemoryCacheManager()
        {
            _allKeys = new ConcurrentDictionary<string, bool>();
        }

        public MemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        #endregion

        #region Utilities

        private MemoryCacheEntryOptions GetMemoryCacheEntryOptions(int cacheTime)
        {
            var options = new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(_cancellationTokenSource.Token))
                .RegisterPostEvictionCallback(PostEviction);

            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cacheTime);

            return options;
        }

        private string AddKey(string key)
        {
            _allKeys.TryAdd(key, true);
            return key;
        }

        private string RemoveKey(string key)
        {
            TryRemoveKey(key);
            return key;
        }

        private void TryRemoveKey(string key)
        {
            if (!_allKeys.TryRemove(key, out bool _))
                _allKeys.TryUpdate(key, false, false);
        }

        private void ClearKeys()
        {
            foreach (var key in _allKeys.Where(p => !p.Value).Select(p => p.Key).ToList())
            {
                RemoveKey(key);
            }
        }

        private void PostEviction(object key, object value, EvictionReason reason, object state)
        {
            if (reason == EvictionReason.Replaced)
                return;

            ClearKeys();

            TryRemoveKey(key.ToString());
        }

        #endregion

        #region Methods

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data != null)
            {
                _cache.Set(AddKey(key), data, GetMemoryCacheEntryOptions(cacheTime));
            }
        }

        public bool IsSet(string key)
        {
            return _cache.TryGetValue(key, out object _);
        }

        public void Remove(string key)
        {
            _cache.Remove(RemoveKey(key));
        }

        public void RemoveByPattern(string pattern)
        {
            this.RemoveByPattern(pattern, _allKeys.Where(p => p.Value).Select(p => p.Key));
        }

        public void Clear()
        {
            _cancellationTokenSource.Cancel();

            _cancellationTokenSource.Dispose();

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Dispose()
        {
        }

        #endregion
    }
}