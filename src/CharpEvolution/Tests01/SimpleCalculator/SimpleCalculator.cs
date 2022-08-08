using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.Tests01.SimpleCalculator
{
    public class SimpleCalculator
    {
        readonly string quit = "Q";
        readonly IEnumerable<string> mathOperations = new string[] { "SOMA", "SUBTRAÇÃO",
                                                                    "MULTIPLICAÇÃO", "DIVISÃO" };

        public void Calculate()//repensar modulariza~ção deste método e nome, o calculate vem depois
        {
            long number1;
            long number2;
            string mathOperation;
            StringBuilder number = new StringBuilder();
            bool isValidOperation = false;
            long result = 0;

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
            isValidOperation = OperationValidator(mathOperation, isValidOperation);

            result = MathOperation.Calculate(mathOperation, number1, number2);

            Console.WriteLine($"O resultado da sua operação é: {result}");
        }

        public class MathOperation
        {
            public static long Calculate(string mathOperation, long number1, long number2)
            {
                MathOperationsFactory mathOperationsFactory = new MathOperationsFactory(mathOperation);
                return mathOperationsFactory.Calculate(mathOperation, number1, number2);
            }
        }

        private bool OperationValidator(string mathOperation, bool isValidOperation)
        {
            foreach (string operation in mathOperations)//iiso aqui deveria estar numa classe de mathOperations
            {
                if (mathOperation.ToUpper() == operation)
                {
                    isValidOperation = true;
                    break;
                }
                else
                {
                    continue;
                }

                Console.WriteLine("Digite uma operação matemática válida. Tente novamente ou " +
                    "pressione 'Q' e pressione 'Enter' para sair da aplicação:");

                if (Console.ReadLine().ToUpper() == quit) { EscapeApplication(); }
                OperationValidator(operation, isValidOperation);
            }

            return isValidOperation;
        }

        private long NumberValidator(string number)
        {
            long numberToLong;

            bool isValidNumber = long.TryParse(number, out numberToLong);

            if (!isValidNumber)
            {
                Console.WriteLine("Digite um número válido. Forneça o número para a operação ou" +
                    "pressione 'Q' para sair da aplicação:");

                var input = Console.ReadLine();

                if (input.ToUpper() == quit.ToUpper())
                {
                    EscapeApplication();
                }

                NumberValidator(input);   
            }
            return numberToLong;

        }

        private void EscapeApplication()
        {
            System.Environment.Exit(0);
        }
    }
}
