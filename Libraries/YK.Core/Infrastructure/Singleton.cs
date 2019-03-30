using System;
using System.Collections.Generic;

namespace YK.Core.Infrastructure
{
    public class Singleton
    {
        static Singleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }

        protected static IDictionary<Type, object> AllSingletons { get; }
    }

    public class Singleton<T> : Singleton
    {
        private static T _instance;

        public static T Instance
        {
            get => _instance;
            set
            {
                _instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        public new static IList<T> Instance => Singleton<IList<T>>.Instance;
    }

    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        public new static IDictionary<TKey, TValue> Instance => Singleton<Dictionary<TKey, TValue>>.Instance;
    }
}