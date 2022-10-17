using CsharpEvolution.Tests01.SimpleCalculator.MathOperations;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;

namespace CsharpEvolution.Tests01.SimpleCalculator.Factory;

public class MathOperationFactory
{
    public static decimal Calculate(string mathOperation, IOperation _operationType, decimal number1, decimal number2)
    {
        switch (mathOperation)
        {
            case "SOMA":
                _operationType = new AdditionOperation();
                break;

            case "SUBTRAÇÃO":
                _operationType = new SubtractionOperation();
                break;

            case "MULTIPLICAÇÃO":
                _operationType = new MultiplicationOperation();
                break;

            case "DIVISÃO":
                _operationType = new DivisionOperation();
                break;
        }
        MathOperationCalculator mathOperationFactory = new MathOperationCalculator(mathOperation, _operationType);
        return mathOperationFactory.Calculate(mathOperation, number1, number2);
    }
}