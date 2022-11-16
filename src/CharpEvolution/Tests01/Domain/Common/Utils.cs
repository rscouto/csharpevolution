using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsharpEvolution.Tests01.SimpleCalculator.Common;

public interface IUtils
{
    void EscapeApplication();
    decimal NumberValidator(string userInput);
    string OperationValidator(string mathOperation);
    void StoreInCache(PerformedOperation performedOperation);
    void WriteCache();
}

public class Utils : IUtils
{
    private readonly string _quit = "Q";
    private readonly IMathOperationFactory _operationFactory;
    private readonly IOperationCache _cache;
    private readonly IUnitOfWorkDbContext _unitOfWorkDbContext;
    private readonly List<string> _mathOperations = new List<string> { "SOMA", "SUBTRAÇÃO",
                                                                "MULTIPLICAÇÃO", "DIVISÃO" };

    public Utils(
        IOperationCache cache,
        IUnitOfWorkDbContext unitOfWorkDbContext,
        IMathOperationFactory operationFactory)
    {
        _cache = cache;
        _unitOfWorkDbContext = unitOfWorkDbContext;
        _operationFactory = operationFactory;
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

    public string OperationValidator(string mathOperation)
    {
        bool isValidOperation = _mathOperations.Any(x => x.Equals(mathOperation, StringComparison.CurrentCultureIgnoreCase));

        while (!isValidOperation)
        {
            Console.WriteLine("Digite uma operação matemática válida. Tente novamente ou " +
            "pressione 'Q' e pressione 'Enter' para sair da aplicação:");
            mathOperation = Console.ReadLine();
            if (mathOperation.Equals(_quit, StringComparison.CurrentCultureIgnoreCase)) { EscapeApplication(); }
            isValidOperation = _mathOperations.Any(x => x.Equals(mathOperation, StringComparison.CurrentCultureIgnoreCase));
        }
        return mathOperation;
    }

    public decimal NumberValidator(string userInput)
    {
        decimal number;

        while (!decimal.TryParse(userInput, out number))
        {
            Console.WriteLine("Digite um número válido. Forneça o número para a operação ou " +
                "pressione 'Q' para sair da aplicação:");

            userInput = Console.ReadLine();

            if (userInput.Equals(_quit, StringComparison.InvariantCultureIgnoreCase))
            {
                EscapeApplication();
            }

        }

        return number;
    }

    public void EscapeApplication()
    {
        Environment.Exit(0);
    }
}
