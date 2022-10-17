using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using System;

namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations;
    public class DivisionOperation : IOperation
    {
        public decimal Calculate(decimal numOne, decimal numTwo)
        {
            try
            {
                return numOne / numTwo;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine(new DivideByZeroException("Não é possível dividir por Zero"));
                throw;
            }
        }
    }