using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

namespace CsharpEvolution.Tests01.SimpleCalculator;

public class MathOperationCalculator
{
    private readonly IOperation _mathOperation;
    public MathOperationCalculator(string operation, IOperation mathOperation)
    {
        _mathOperation = mathOperation;
    }

    public decimal Calculate(string mathOperation, decimal numOne, decimal numTwo)
    {
        return _mathOperation.Calculate(numOne, numTwo);
    }
}
