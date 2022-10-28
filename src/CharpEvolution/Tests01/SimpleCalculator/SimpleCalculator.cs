﻿using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsharpEvolution.Tests01.SimpleCalculator
{
    public interface ISimpleCalculator
    {
        void Calculate();
    }

    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly string _quit = "Q";
        private long cacheCount = 0;
        long itemCount = 0;
        private readonly IMathOperationFactory _operationFactory;
        private readonly IOperationCache _cache;
        private readonly ICalculatorRepository _repository;
        private readonly List<string> _mathOperations = new List<string> { "SOMA", "SUBTRAÇÃO",
                                                                    "MULTIPLICAÇÃO", "DIVISÃO" };

        public SimpleCalculator(IOperationCache cache, ICalculatorRepository repository, IMathOperationFactory operationFactory)
        {
            _cache = cache;
            _repository = repository;
            _operationFactory = operationFactory;
        }

        public void Calculate()
        {

            var foo = CollectOperationInfo();

            var result = _operationFactory.Calculate(foo.mathOperation, foo.number1, foo.number2);

            var performedOperation = new PerformedOperation(foo.mathOperation, foo.number1, foo.number2, result);

            //_repository.Create(performedOperation); 
            StoreInCache(performedOperation);

            Console.WriteLine($"O resultado da sua operação é: {result}");
            Console.WriteLine("Deseja efetuar mais alguma operação? S/N");
            var input = Console.ReadLine().ToUpper();

            Console.Clear();

            if (input == "S") { Calculate(); }
            EscapeApplication();

        }

        private void StoreInCache(PerformedOperation performedOperation)
        {
            _cache.AddToCache(performedOperation);
            cacheCount++;

            if (cacheCount % 2 == 0)
            {
                WriteCache();
            }
        }

        private void WriteCache()
        {
            var inCacheOperations = _cache.GetOperations();

            StringBuilder stringWithAllOperations = new StringBuilder();

            foreach (var operation in inCacheOperations)
            {
                itemCount++;
                stringWithAllOperations.Append($"{itemCount}       {operation.MathOperation}             " +
                    $"Parâmetros(A = {operation.NumOne}, B = {operation.NumTwo}) {operation.Result}\n");
            }

            File.WriteAllText("MathOperations.txt", stringWithAllOperations.ToString().Trim());

        }

        private (decimal number1, decimal number2, string mathOperation) CollectOperationInfo()
        {
            Console.WriteLine("Digite o primeiro número para a operação:");
            var number1 = NumberValidator(Console.ReadLine());

            Console.WriteLine("Digite o segundo número para a operação:");
            var number2 = NumberValidator(Console.ReadLine());

            Console.WriteLine("Digite uma das operações matemáticas a seguir:" +
                "\n* Soma \n* Subtração \n* Multiplicação \n* Divisão");

            var mathOperation = OperationValidator(Console.ReadLine());

            return (number1, number2, mathOperation);
        }

        private string OperationValidator(string mathOperation)
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

        private decimal NumberValidator(string userInput)
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

        private void EscapeApplication()
        {
            System.Environment.Exit(0);
        }
    }
}
