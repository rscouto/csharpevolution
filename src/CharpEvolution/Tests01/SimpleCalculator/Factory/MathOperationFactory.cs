﻿using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using System;
using System.Collections.Generic;

namespace CsharpEvolution.Tests01.SimpleCalculator.Factory;

public interface IMathOperationFactory
{
    decimal Calculate(string mathOperation, decimal number1, decimal number2);
}

public class MathOperationFactory : IMathOperationFactory
{
    private readonly IReadOnlyDictionary<OperationType, IOperation> _operations;

    public MathOperationFactory(IReadOnlyDictionary<OperationType, IOperation> operations)
    {
        _operations = operations;  
    }
    public decimal Calculate(string mathOperation, decimal number1, decimal number2)
    {
        Enum.TryParse(mathOperation.ToUpper(), out OperationType operationType);

        if (!_operations.TryGetValue(operationType, out var handler))
            throw new ArgumentException("Operação não reconhecida");
        return handler.Calculate(number1, number2);
        
    }
}
