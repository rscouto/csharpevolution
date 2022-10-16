namespace CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

public interface IOperation
{
    public long Calculate(long numOne, long optionalNumTwo = 0);
}
