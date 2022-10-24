using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace CsharpEvolution.Tests01.SimpleCalculator
{
    public interface IOperationCache
    {
        void AddToCache(PerformedOperation operation);
        List<PerformedOperation> GetOperations();
    }

    public class OperationCache : IOperationCache
    {
        private const string key = "MyKey";
        private readonly IMemoryCache _cache;
        List<PerformedOperation> listOfOperations = new ();

        public OperationCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public List<PerformedOperation> GetOperations()
        {

            if (_cache.TryGetValue(key, out List<PerformedOperation> operations))
            {
                return operations;
            }
            else
            {
            _cache.Set(key, operations);
            return operations;
            }
        }

        public void AddToCache(PerformedOperation operation)
        {
            
            listOfOperations.Add(operation);

            var option = new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(30),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
            };

            _cache.Set(key, listOfOperations, option);
        }

    }
}
