using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.Tests01.SimpleCalculator
{
    
    public static class MathOperationCalculator //: IMathOperationCalculator
    {
        public static long CalculateSum(long numOne, long numTwo)
        {
            return numOne + numTwo;
        }

        public static long CalculateSubtraction(long numOne, long numTwo)
        {
            return numOne - numTwo;
        }

        public static long CalculateMultiply(long numOne, long numTwo)
        {
            return numOne * numTwo;
        }

        public static long CalculateDivision(long numOne, long numTwo)
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
}
