using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsharpEvolution.Tests01.SimpleCalculator.Entities;

public class PerformedOperation
{
    public PerformedOperation()
    {
    }

    public PerformedOperation(string mathOperation, decimal numOne, decimal numTwo, decimal result)
    {
        MathOperation = mathOperation;
        NumOne = numOne;
        NumTwo = numTwo;
        Result = result;
    }

    public int Id { get; set; }
    public string MathOperation { get; set; }
    public decimal NumOne { get; set; }
    public decimal NumTwo { get; set; }
    public decimal Result { get; set; }
}
