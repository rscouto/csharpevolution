using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution.Tests01.SimpleCalculator
{
    public interface IMathOperationCalculator
    {
        long CalculateDivision(long numOne, long numTwo);
        long CalculateMultiply(long numOne, long numTwo);
        long CalculateSubtraction(long numOne, long numTwo);
        long CalculateSum(long numOne, long numTwo);
    }
}
