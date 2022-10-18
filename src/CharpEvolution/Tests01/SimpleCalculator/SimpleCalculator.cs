using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IOperation _operationType;
        private readonly IMemoryCache _cache;
        private const string operationKey = "operation";
        private List<PerformedOperation> listOfOperations = new List<PerformedOperation>();
        private readonly IEnumerable<string> _mathOperations = new string[] { "SOMA", "SUBTRAÇÃO",
                                                                    "MULTIPLICAÇÃO", "DIVISÃO" };

        public SimpleCalculator(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Calculate()
        {

            var isValid = CollectOperationInfo(out var number1, out var number2, out var mathOperation);

            if (isValid)
            {
                var result = MathOperationFactory.Calculate(mathOperation, _operationType, number1, number2);

                var performedOperation = new PerformedOperation(mathOperation, number1, number2, result);


                StoreInCache(performedOperation);

                Console.WriteLine($"O resultado da sua operação é: {result}");
                Console.WriteLine("Deseja efetuar mais alguma operação? S/N");
                var input = Console.ReadLine().ToUpper();

                Console.Clear();

                if (input == "S") { Calculate(); }
                EscapeApplication();
            }

            //remover daqui pra baixo
            //Console.WriteLine(_cache.TryGetValue(operationKey, out performedOperation));
            //var list = new List<PerformedOperation>() { performedOperation };
            //Console.WriteLine(list.Count);

        }

        private void StoreInCache(PerformedOperation performedOperation)
        {
            listOfOperations.Add(performedOperation);
            _cache.Set(operationKey, performedOperation);
            cacheCount++;

            if (listOfOperations.Count % 2 == 0)
            {
                WriteCache(listOfOperations);
                //_cache.Dispose();
            }
        }

        private void WriteCache(List<PerformedOperation> listOfOperations)
        {

            var inCacheOperations = _cache.Get(operationKey);

            //List<object> collectionOfOperations = new List<object>();
            //collectionOfOperations.Add(_cache.Get(operationKey));
            StringBuilder stringWithAllOperations = new StringBuilder();

            foreach (var operation in listOfOperations)
            {
                itemCount++;
                stringWithAllOperations.Append($"{itemCount}       {operation.MathOperation}             " +
                    $"Parâmetros(A = {operation.NumOne}, B = {operation.NumTwo}) {operation.Result}\n");
            }

            stringWithAllOperations.AppendJoin("", stringWithAllOperations.ToString());

            File.WriteAllText("MathOperations.txt", stringWithAllOperations.ToString().Trim());

        }

        private bool CollectOperationInfo(out decimal number1, out decimal number2, out string mathOperation)
        {
            Console.WriteLine("Digite o primeiro número para a operação:");
            number1 = NumberValidator(Console.ReadLine());

            Console.WriteLine("Digite o segundo número para a operação:");
            number2 = NumberValidator(Console.ReadLine());

            Console.WriteLine("Digite uma das operações matemáticas a seguir:" +
                "\n* Soma \n* Subtração \n* Multiplicação \n* Divisão");

            mathOperation = Console.ReadLine().ToUpper();

            return OperationValidator(mathOperation);
        }

        private bool OperationValidator(string mathOperation)
        {
            //TODO remover recursividade como no NumberValidator 
            bool isValidOperation = false;

            foreach (string operation in _mathOperations)
            {
                if (mathOperation.Equals(operation, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }

                Console.WriteLine("Digite uma operação matemática válida. Tente novamente ou " +
                    "pressione 'Q' e pressione 'Enter' para sair da aplicação:");

                mathOperation = Console.ReadLine();

                if (mathOperation.Equals(_quit, StringComparison.CurrentCultureIgnoreCase)) { EscapeApplication(); }
                else { OperationValidator(mathOperation); }
            }
            return false; ;
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
