using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using System;

namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations;
    public class DivisionOperation : IOperation
    {
        public long Calculate(long numOne, long numTwo)
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