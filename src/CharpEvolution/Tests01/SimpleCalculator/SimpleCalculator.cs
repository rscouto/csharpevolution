using CsharpEvolution.Tests01.Persistence;
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
        private readonly IMathOperationFactory _operationFactory;
        private readonly IOperationCache _cache;
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IUnitOfWorkDbContext _unitOfWorkDbContext;
        private readonly List<string> _mathOperations = new List<string> { "SOMA", "SUBTRAÇÃO",
                                                                    "MULTIPLICAÇÃO", "DIVISÃO" };

        public SimpleCalculator(
            IOperationCache cache,
            IUnitOfWork unitOfWork,
            IUnitOfWorkDbContext unitOfWorkDbContext,   
            IMathOperationFactory operationFactory)
        {
            _cache = cache;
            _unitOfWork = unitOfWork;
            _unitOfWorkDbContext = unitOfWorkDbContext;
            _operationFactory = operationFactory;
        }

        public void Calculate()
        {
            var userInput = CollectOperationInfo();

            var result = _operationFactory.Calculate(userInput.mathOperation, userInput.number1, userInput.number2);

            var performedOperation = new PerformedOperation(userInput.mathOperation, userInput.number1, userInput.number2, result);

            _unitOfWorkDbContext.DbContextRepository.Create(performedOperation);
            var persistedId = _unitOfWork.CalculatorRepository.Create(performedOperation);

            performedOperation.Id = persistedId;

            _unitOfWorkDbContext.DbContextRepository.Find();
            _unitOfWork.CalculatorRepository.Find();    
           
            StoreInCache(performedOperation);

            Console.WriteLine($"O resultado da sua operação é: {result}");
            Console.WriteLine("Deseja efetuar mais alguma operação? S/N");
            var input = Console.ReadLine();

            Console.Clear();

            if (input.Equals("s",StringComparison.CurrentCultureIgnoreCase)) { Calculate(); }
            EscapeApplication();
        }

        private void StoreInCache(PerformedOperation performedOperation)
        {
            _cache.AddToCache(performedOperation);

            if (_cache.GetOperations().Count() % 2 == 0)
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
                stringWithAllOperations.Append($"{operation.Id}       {operation.MathOperation}             " +
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
                "\n* Soma \n* Subtração \n* Multiplicação \n* Divisão\n");

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
