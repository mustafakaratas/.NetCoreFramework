﻿namespace Core.CrossCuttingConcerns.Cache
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsExist(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
