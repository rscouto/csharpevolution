using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.SimpleCalculator
{
    public interface IOperationCache
    {
        void AddToCache(IEnumerable<PerformedOperation> operation);
        List<PerformedOperation> GetOperations();
    }

    public class OperationCache : IOperationCache
    {
        private const string key = "MyKey";
        private readonly IMemoryCache _cache;

        public OperationCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void AddToCache(IEnumerable<PerformedOperation> operation)
        {
            var option = new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(1),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3),
            };

            _cache.Set<IEnumerable<PerformedOperation>>(key, new List<PerformedOperation>()
            {
                new PerformedOperation()
            }, option);
        }

        public List<PerformedOperation> GetOperations()
        {
            List<PerformedOperation> operations;

            if (!_cache.TryGetValue(key, out operations))
            {
                operations = new List<PerformedOperation>() { new PerformedOperation() };

                AddToCache(operations);
            }

            return _cache.Get<List<PerformedOperation>>(key);
        }
    }
}
