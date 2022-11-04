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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string MathOperation { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,5)")]
    public decimal NumOne { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,5)")]
    public decimal NumTwo { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,5)")]
    public decimal Result { get; set; }
}
