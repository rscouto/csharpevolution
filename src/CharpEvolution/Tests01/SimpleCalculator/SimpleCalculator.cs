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
    public partial class SimpleCalculator
    {
        private readonly string _quit = "Q";
        private long cacheCount = 0;
        long itemCount = 0;
        decimal numberToDecimal;
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
            decimal number1, number2, result;
            string mathOperation;

            var isValid = CollectOperationInfo(out number1, out number2, out mathOperation);

            if (isValid)
            {
                result = MathOperationFactory.Calculate(mathOperation, _operationType, number1, number2);

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

            if(listOfOperations.Count % 2 == 0) 
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
            StringBuilder number = new StringBuilder();
            bool isValidOperation = false;

            Console.WriteLine("Digite o primeiro número para a operação:");
            number.Append(Console.ReadLine());
            number1 = NumberValidator(number.ToString());
            number.Clear();

            Console.WriteLine("Digite o segundo número para a operação:");
            number.Append(Console.ReadLine());
            number2 = NumberValidator(number.ToString());
            number.Clear();

            Console.WriteLine("Digite uma das operações matemáticas a seguir:" +
                "\n* Soma \n* Subtração \n* Multiplicação \n* Divisão");

            mathOperation = Console.ReadLine().ToUpper();

            return OperationValidator(mathOperation, isValidOperation);
        }

        private bool OperationValidator(string mathOperation, bool isValidOperation)
        {
            foreach (string operation in _mathOperations)
            {
                if (mathOperation.ToUpper() == operation)
                {
                    isValidOperation = true;
                    break;
                }
                else { continue; }

                Console.WriteLine("Digite uma operação matemática válida. Tente novamente ou " +
                    "pressione 'Q' e pressione 'Enter' para sair da aplicação:");

                var input = Console.ReadLine().ToUpper();

                if (input == _quit.ToUpper()) { EscapeApplication(); }
                else { OperationValidator(input, isValidOperation); }
            }
            return isValidOperation;
        }

        private decimal NumberValidator(string number)
        {
            bool isValidNumber = decimal.TryParse(number, out numberToDecimal);

            if (!isValidNumber)
            {
                Console.WriteLine("Digite um número válido. Forneça o número para a operação ou " +
                    "pressione 'Q' para sair da aplicação:");

                var input = Console.ReadLine();

                if (input.ToUpper() == _quit.ToUpper())
                {
                    EscapeApplication();
                }

                else { NumberValidator(input); }
            }

            return numberToDecimal;
        }

        private void EscapeApplication()
        {
            System.Environment.Exit(0);
        }
    }
}
