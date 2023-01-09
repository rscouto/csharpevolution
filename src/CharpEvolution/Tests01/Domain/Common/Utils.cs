using CsharpEvolution.Tests01.Infrastructure;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CsharpEvolution.Tests01.SimpleCalculator.Common;

public interface IUtils
{
    void EscapeApplication();
    void StoreInCache(PerformedOperation performedOperation);
    void WriteCache();
}

public class Utils : IUtils
{
    private readonly string _quit = "Q";
    private readonly IOperationCache _cache;

    public Utils(IOperationCache cache)
    {
        _cache = cache;
    }

    public void StoreInCache(PerformedOperation performedOperation)
    {
        _cache.AddToCache(performedOperation);

        if (_cache.GetOperations().Count() % 2 == 0)
        {
            WriteCache();
        }
    }

    public void WriteCache()
    {
        var inCacheOperations = _cache.GetOperations();

        StringBuilder stringWithAllOperations = new StringBuilder();

        foreach (var operation in inCacheOperations)
        {
            stringWithAllOperations.Append($"{operation.Id}       {operation.MathOperation}             " +
                $"Parâmetros(A = {operation.NumOne}, B = {operation.NumTwo}) {operation.Result}\n");
        }

        File.WriteAllText("MathOperations.txt", stringWithAllOperations.ToString().Trim());
    }

    public void EscapeApplication()
    {
        Environment.Exit(0);
    }
}
