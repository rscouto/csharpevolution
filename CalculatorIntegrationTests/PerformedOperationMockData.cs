using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorIntegrationTests;
public class PerformedOperationMockData
{
    public static async Task CreatePerformedOperations(CalculatorApiApplication application, bool create)
    {
        using (var scope = application.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using (var calculatorDbContext = provider.GetRequiredService<PerformedOperationContext>())
            {
                await calculatorDbContext.Database.EnsureCreatedAsync();

                if (create)
                {
                    await calculatorDbContext.Operations.AddAsync(new PerformedOperation
                    { Id = 1, MathOperation = "Soma", NumOne = 15, NumTwo = 25, Result = 40 });

                    await calculatorDbContext.Operations.AddAsync(new PerformedOperation
                    { Id = 2, MathOperation = "Subtração", NumOne = 30, NumTwo = 10, Result = 20 });

                    await calculatorDbContext.Operations.AddAsync(new PerformedOperation
                    { Id = 3, MathOperation = "Multiplicação", NumOne = 10, NumTwo = 40, Result = 400 });

                    await calculatorDbContext.Operations.AddAsync(new PerformedOperation
                    { Id = 4, MathOperation = "Divisão", NumOne = 20, NumTwo = 40, Result = 0.5M });

                    await calculatorDbContext.SaveChangesAsync();
                }
            }
        }
    }
}
