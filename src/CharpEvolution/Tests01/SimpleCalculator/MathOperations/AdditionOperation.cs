using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations;

public class AdditionOperation : IOperation 
{
    public long Calculate(long numOne, long numTwo)
    {
        return numOne + numTwo;
    }
}
