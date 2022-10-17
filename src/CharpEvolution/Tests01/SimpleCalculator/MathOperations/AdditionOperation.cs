using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations; 

public class AdditionOperation : IOperation 
{
    public decimal Calculate(decimal numOne, decimal numTwo)
    {
        return numOne + numTwo;
    }
}
