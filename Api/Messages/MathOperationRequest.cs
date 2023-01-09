﻿using CsharpEvolution.Tests01.Domain.MathOperations.Enums;
using FluentValidation;

namespace Api.Messages;

public class MathOperationRequest
{
    public MathOperation operation { get; set; }
    public decimal NumOne { get; set; }
    public decimal NumTwo { get; set; }
}

public sealed class MathOperationRequestValidator : AbstractValidator<MathOperationRequest>
{
    public MathOperationRequestValidator()
    {
        RuleFor(x => x.operation)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.NumOne).NotEmpty();

        RuleFor(x => x.NumTwo).NotEmpty();
    }
}
