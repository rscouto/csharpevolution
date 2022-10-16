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
        void AddToCache(PerformedOperation performedOpewration);
        List<IOperation> GetOperations();
    }

    public class OperationCache : IOperationCache
    {
        private const string key = "MyKey";
        private readonly IMemoryCache _cache;

        public OperationCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void AddToCache(PerformedOperation performedOpewration)
        {

        }

        public List<IOperation> GetOperations()
        {
            return _cache.Get<List<IOperation>>(key);
        }
    }
}
