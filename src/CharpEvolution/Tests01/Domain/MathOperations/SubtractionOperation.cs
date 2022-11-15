using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations;

public class SubtractionOperation : IOperation
{
    public decimal Calculate(decimal numOne, decimal numTwo)
    {
        if (numTwo < 0) {return numOne + numTwo;}

        return numOne - numTwo;
    }
}
