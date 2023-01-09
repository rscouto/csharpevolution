using System.ComponentModel;

namespace CsharpEvolution.Tests01.Domain.MathOperations.Enums;
public enum MathOperation
{
    [Description("Soma")]
    Addition = 0,

    [Description("Subtração")]
    Subtraction = 1,

    [Description("Multiplicação")]
    Multiplication = 2,

    [Description("Divisão")]
    Division = 3
}
